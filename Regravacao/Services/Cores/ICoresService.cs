using Regravacao.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Regravacao.Services.Cores
{
    public interface ICoresService
    {
        Task<List<CoresDto>> ListarCoresAsync();
    }
}
