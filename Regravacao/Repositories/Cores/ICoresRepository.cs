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
    }
}
