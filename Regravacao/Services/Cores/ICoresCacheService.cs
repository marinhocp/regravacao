using Regravacao.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Regravacao.Services.Cores
{
    public interface ICoresCacheService
    {
        /// <summary>
        /// Retorna a lista mestre das cores (carrega do cache local se existir, senão do Supabase).
        /// </summary>
        Task<List<CoresDto>> GetCoresCachedAsync();

        /// <summary>
        /// Força uma sincronização imediata com o Supabase e atualiza o cache local.
        /// </summary>
        Task<List<CoresDto>> RefreshFromRemoteAsync();

        /// <summary>
        /// Expondo um atalho em português caso outras partes do projeto chamem esse nome.
        /// </summary>
        Task SalvarCacheLocalAsync(List<CoresDto> lista);
    }
}
