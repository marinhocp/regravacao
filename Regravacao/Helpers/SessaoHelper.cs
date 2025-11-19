using System;
using System.IO;
using System.Text.Json;
using Supabase.Gotrue;

namespace Regravacao.Helpers
{
    public class SessaoPersistida
    {
        public required string AccessToken { get; set; }
        public required string RefreshToken { get; set; }
        public DateTime ExpiresAt { get; set; }
    }

    public static class SessaoHelper
    {
        private static readonly string CaminhoArquivo = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            "Regravacao",
            "sessao.json"
        );

        public static void SalvarSessao(Session session)
        {
            try
            {
                if (session == null) return;

                var pasta = Path.GetDirectoryName(CaminhoArquivo);
                if (!Directory.Exists(pasta))
                    Directory.CreateDirectory(pasta);

                var expiresAt = session.ExpiresAt(); // ← DateTime (não nullable)

                var sessaoPersistida = new SessaoPersistida
                {
                    AccessToken = session.AccessToken ?? string.Empty,
                    RefreshToken = session.RefreshToken ?? string.Empty,
                    ExpiresAt = expiresAt
                };

                var json = JsonSerializer.Serialize(sessaoPersistida, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(CaminhoArquivo, json);
            }
            catch { }
        }

        public static SessaoPersistida? CarregarSessao()
        {
            try
            {
                if (File.Exists(CaminhoArquivo))
                {
                    var json = File.ReadAllText(CaminhoArquivo);
                    return JsonSerializer.Deserialize<SessaoPersistida>(json);
                }
            }
            catch { }
            return null;
        }

        public static void LimparSessao()
        {
            try
            {
                if (File.Exists(CaminhoArquivo))
                    File.Delete(CaminhoArquivo);
            }
            catch { }
        }
    }
}