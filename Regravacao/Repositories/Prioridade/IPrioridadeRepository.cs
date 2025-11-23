using Regravacao.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Regravacao.Repositories.Prioridade
{
    public interface IPrioridadeRepository
    {
        Task<List<PrioridadeDto>> ListarTodosAsync();
    }
}