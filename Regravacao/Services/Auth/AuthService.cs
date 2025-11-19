using Regravacao.Helpers;
using Supabase;


namespace Regravacao.Services.Auth
{
    public class AuthService : IAuthService
    {

        private readonly Client _supabase;

        public AuthService( Client supabase)
        {
            _supabase = supabase;
        }

        // ======================================================
        // ✅ LOGOUT COMPLETO (Remoto + Local + Memória)
        // ======================================================
        public async Task EfetuarLogoutAsync()
        {
            try
            {
                // 🔹 1. Logout remoto no Supabase (encerra a sessão ativa)
                await _supabase.Auth.SignOut();

                // 🔹 2. Limpa o arquivo local de sessão persistida
                SessaoHelper.LimparSessao();

                // 🔹 3. Reseta a sessão em memória
                try
                {
                    await _supabase.Auth.SetSession(null, null);
                }
                catch
                {
                    // Alguns SDKs podem lançar exceção, então ignoramos com segurança
                }

                Console.WriteLine("✅ Logout completo realizado com sucesso.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"⚠️ Erro ao efetuar logout: {ex.Message}");
            }
        }

    }
}
