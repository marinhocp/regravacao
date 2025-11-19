using Regravacao.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Regravacao.Services.Conferente
{
    public interface IConferenteService
    {
        Task<List<FuncionariosDto>> ListarConferentesAsync();
    }
}