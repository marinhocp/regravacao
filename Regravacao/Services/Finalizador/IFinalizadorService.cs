using Regravacao.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Regravacao.Services.Finalizador
{
    public interface IFinalizadorService
    {
        Task<List<FuncionariosDto>> ListarFinalizadoresAsync();
    }
}