using Regravacao.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Regravacao.Services.Cores
{
    public interface ICoresService
    {
        Task<List<CoresDto>> ListarCoresAsync();

        /// <summary>
        /// Busca cores que começam com o termo no repositório.
        /// </summary>
        Task<List<CoresDto>> BuscarCoresPorNomeAsync(string termo);
    }
}