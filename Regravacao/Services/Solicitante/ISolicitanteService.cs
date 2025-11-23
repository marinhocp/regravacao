using Regravacao.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Regravacao.Services.Solicitante
{
    public interface ISolicitanteService
    {
        Task<List<FuncionariosDto>> ListarSolicitanteAsync();
    }
}