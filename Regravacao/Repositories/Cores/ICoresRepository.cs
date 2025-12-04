using Regravacao.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Regravacao.Repositories
{
    public interface ICoresRepository
    {
        /// <summary>
        /// Retorna todas as cores da tabela TblCores de forma assíncrona.
        /// </summary>
        Task<List<CoresDto>> ListarTodasAsync();

        /// <summary>
        /// Busca cores da tabela TblCores que começam com o termo fornecido.
        /// </summary>
        Task<List<CoresDto>> BuscarCoresPorNomeAsync(string termo);
    }
}