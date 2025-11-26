using Regravacao.DTOs;
using Regravacao.Repositories;
using Regravacao.Services.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Regravacao.Services.Cores
{
    public class CoresCacheService : ICoresCacheService
    {
        private readonly ICoresRepository _coresRepository;
        private readonly string _cacheFilePath;
        private readonly string _cacheMetaFilePath;
        private readonly TimeSpan _backgroundDelay = TimeSpan.FromSeconds(1);
        private List<CoresDto> _memCache = new List<CoresDto>();
        private readonly object _lock = new object();

        public CoresCacheService(ICoresRepository coresRepository)
        {
            _coresRepository = coresRepository ?? throw new ArgumentNullException(nameof(coresRepository));

            var appFolder = CacheFileHelper.GetAppCacheFolder();
            _cacheFilePath = Path.Combine(appFolder, "cores.cache.json");
            _cacheMetaFilePath = Path.Combine(appFolder, "cores.cache.meta.json");
        }

        public async Task<List<CoresDto>> GetCoresCachedAsync()
        {
            // 1) Tenta carregar cache JSON local
            var local = await LoadCacheLocalAsync();
            if (local != null && local.Any())
            {
                lock (_lock) _memCache = local;
                _ = Task.Run(async () => await BackgroundSyncIfNeeded());
                return CloneList(local);
            }

            // 2) Tenta carregar CSV local, converte e salva como JSON
            var csv = await LoadCsvIfExistsAsync();
            if (csv != null && csv.Any())
            {
                await SaveCacheLocalInternalAsync(csv);
                lock (_lock) _memCache = csv;
                _ = Task.Run(async () => await BackgroundSyncIfNeeded());
                return CloneList(csv);
            }

            // 3) fallback: obtém do remoto
            var remote = await SafeFetchRemoteAsync();
            if (remote != null)
            {
                await SaveCacheLocalInternalAsync(remote);
                lock (_lock) _memCache = remote;
                _ = Task.Run(async () => await BackgroundSyncIfNeeded());
                return CloneList(remote);
            }

            return new List<CoresDto>();
        }

        public async Task<List<CoresDto>> RefreshFromRemoteAsync()
        {
            var remote = await SafeFetchRemoteAsync();
            if (remote == null) return CloneList(_memCache);
            await SaveCacheLocalInternalAsync(remote);
            lock (_lock) _memCache = remote;
            return CloneList(remote);
        }

        // Método público em pt-br para compatibilidade (p.ex. se outras partes chamam SalvarCacheLocalAsync)
        public async Task SalvarCacheLocalAsync(List<CoresDto> lista)
        {
            await SaveCacheLocalInternalAsync(lista);
        }

        private async Task BackgroundSyncIfNeeded()
        {
            try
            {
                await Task.Delay(_backgroundDelay);
                var remote = await SafeFetchRemoteAsync();
                if (remote == null) return;
                var local = CloneList(_memCache);
                if (!AreListsEqualByChecksum(local, remote))
                {
                    await SaveCacheLocalInternalAsync(remote);
                    lock (_lock) _memCache = remote;
                }
            }
            catch
            {
                // swallow
            }
        }

        private async Task<List<CoresDto>?> SafeFetchRemoteAsync()
        {
            try
            {
                return await _coresRepository.ListarTodasAsync();
            }
            catch
            {
                return null;
            }
        }

        private static List<CoresDto> CloneList(List<CoresDto> src)
        {
            return src.Select(x => new CoresDto
            {
                IdCor = x.IdCor,
                Paleta = x.Paleta,
                NomeCor = x.NomeCor,
                CodigoHexadecimal = x.CodigoHexadecimal,
                CodigoRgb = x.CodigoRgb,
                CodigoCmyk = x.CodigoCmyk
            }).ToList();
        }

        private static bool AreListsEqualByChecksum(List<CoresDto> a, List<CoresDto> b)
        {
            string s1 = string.Join('|', a.OrderBy(x => x.IdCor).Select(x => $"{x.IdCor}:{x.NomeCor}:{x.CodigoHexadecimal}"));
            string s2 = string.Join('|', b.OrderBy(x => x.IdCor).Select(x => $"{x.IdCor}:{x.NomeCor}:{x.CodigoHexadecimal}"));
            return ComputeSha1(s1) == ComputeSha1(s2);
        }

        private static string ComputeSha1(string input)
        {
            using var sha = SHA1.Create();
            var bytes = Encoding.UTF8.GetBytes(input ?? string.Empty);
            var hash = sha.ComputeHash(bytes);
            return Convert.ToHexString(hash);
        }

        private async Task<List<CoresDto>?> LoadCacheLocalAsync()
        {
            try
            {
                if (!File.Exists(_cacheFilePath)) return null;
                var json = await File.ReadAllTextAsync(_cacheFilePath);
                var opts = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var list = JsonSerializer.Deserialize<List<CoresDto>>(json, opts);
                return list;
            }
            catch
            {
                return null;
            }
        }

        private async Task<List<CoresDto>?> LoadCsvIfExistsAsync()
        {
            try
            {
                var csvPath = Path.Combine(CacheFileHelper.GetAppCacheFolder(), "cores.csv");
                if (!File.Exists(csvPath)) return null;

                var lines = await File.ReadAllLinesAsync(csvPath);
                if (lines.Length == 0) return null;

                var list = new List<CoresDto>();
                // assume header; tenta inferir se tem cabeçalho
                int start = 0;
                if (lines[0].ToLower().Contains("id") || lines[0].ToLower().Contains("paleta")) start = 1;

                for (int i = start; i < lines.Length; i++)
                {
                    var line = lines[i];
                    if (string.IsNullOrWhiteSpace(line)) continue;
                    // suporta separador ; ou ,
                    var parts = line.Split(new[] { ';', ',' });
                    // garantir existência de colunas: id;paleta;nome;hex;rgb;cmyk
                    if (parts.Length < 4) continue;
                    int.TryParse(parts[0], out int id);
                    var dto = new CoresDto
                    {
                        IdCor = id,
                        Paleta = parts.Length > 1 ? parts[1].Trim() : string.Empty,
                        NomeCor = parts.Length > 2 ? parts[2].Trim() : string.Empty,
                        CodigoHexadecimal = parts.Length > 3 ? parts[3].Trim() : string.Empty,
                        CodigoRgb = parts.Length > 4 ? parts[4].Trim() : string.Empty,
                        CodigoCmyk = parts.Length > 5 ? parts[5].Trim() : string.Empty
                    };
                    list.Add(dto);
                }

                return list;
            }
            catch
            {
                return null;
            }
        }

        private async Task SaveCacheLocalInternalAsync(List<CoresDto> list)
        {
            try
            {
                var opts = new JsonSerializerOptions { WriteIndented = true };
                var json = JsonSerializer.Serialize(list, opts);
                await File.WriteAllTextAsync(_cacheFilePath, json);

                var meta = new
                {
                    SavedAt = DateTime.UtcNow,
                    Checksum = ComputeSha1(string.Join('|', list.OrderBy(x => x.IdCor).Select(x => $"{x.IdCor}:{x.NomeCor}:{x.CodigoHexadecimal}")))
                };
                var metaJson = JsonSerializer.Serialize(meta, opts);
                await File.WriteAllTextAsync(_cacheMetaFilePath, metaJson);
            }
            catch
            {
                // ignore
            }
        }
    }
}
