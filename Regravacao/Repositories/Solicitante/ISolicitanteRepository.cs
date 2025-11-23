using Regravacao.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Regravacao.Repositories.Solicitante
{
    public interface ISolicitanteRepository
    {
        Task<List<FuncionariosDto>> ListarPorCargosAsync(List<int> idsCargos);
    }
}