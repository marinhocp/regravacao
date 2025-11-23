using Regravacao.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Regravacao.Repositories.Status
{
    public interface IStatusRepository
    {
        Task<List<StatusDto>> ListarTodosAsync();
    }
}