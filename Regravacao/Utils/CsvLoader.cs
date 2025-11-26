using Regravacao.DTOs;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Regravacao.Services.Cores.Utils
{
    public static class CsvLoader
    {
        public static async Task<List<CoresDto>> ParseCoresCsvAsync(string path)
        {
            var list = new List<CoresDto>();
            if (!File.Exists(path)) return list;

            using var sr = new StreamReader(path, Encoding.UTF8);
            string? header = await sr.ReadLineAsync(); // header (pula)

            while (!sr.EndOfStream)
            {
                var line = await sr.ReadLineAsync();
                if (string.IsNullOrWhiteSpace(line)) continue;

                // separa por ';' respeitando aspas simples (simples parser)
                var parts = SplitCsvLine(line, ';');
                // Esperamos pelo menos 6 colunas: id_cor;paleta;nome_cor;codigo_hexadecimal;codigo_rgb;codigo_cmyk
                if (parts.Length < 3) continue;

                int id = 0;
                int.TryParse(parts[0], NumberStyles.Integer, CultureInfo.InvariantCulture, out id);

                var dto = new CoresDto
                {
                    IdCor = id,
                    Paleta = parts.Length > 1 ? parts[1] : string.Empty,
                    NomeCor = parts.Length > 2 ? parts[2] : string.Empty,
                    CodigoHexadecimal = parts.Length > 3 ? parts[3] : string.Empty,
                    CodigoRgb = parts.Length > 4 ? parts[4] : string.Empty,
                    CodigoCmyk = parts.Length > 5 ? parts[5] : string.Empty
                };

                list.Add(dto);
            }

            return list;
        }

        private static string[] SplitCsvLine(string line, char sep)
        {
            var result = new List<string>();
            bool inQuotes = false;
            var cur = new StringBuilder();
            for (int i = 0; i < line.Length; i++)
            {
                var c = line[i];
                if (c == '"')
                {
                    if (inQuotes && i + 1 < line.Length && line[i + 1] == '"')
                    {
                        cur.Append('"');
                        i++;
                    }
                    else
                    {
                        inQuotes = !inQuotes;
                    }
                }
                else if (c == sep && !inQuotes)
                {
                    result.Add(cur.ToString());
                    cur.Clear();
                }
                else
                {
                    cur.Append(c);
                }
            }
            result.Add(cur.ToString());
            return result.ToArray();
        }
    }
}
