namespace Regravacao.Services.Auth
{
    public interface IAuthService
    {
        /// Efetua o logout do usuário no Supabase e encerra a sessão local.
        Task EfetuarLogoutAsync();
    }
}
