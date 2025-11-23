using Regravacao.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Regravacao.Services.Status
{
    public interface IStatusService
    {
        Task<List<StatusDto>> ObterTodosStatusAsync();
    }
}