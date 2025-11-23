using Regravacao.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Regravacao.Services.Prioridade
{
    public interface IPrioridadeService
    {
        Task<List<PrioridadeDto>> ObterTodasPrioridadesAsync();
    }
}