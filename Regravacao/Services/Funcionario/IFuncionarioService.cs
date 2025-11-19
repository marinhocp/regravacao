using Regravacao.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Regravacao.Services.Funcionario
{
    public interface IFuncionarioService
    {
        Task<List<FuncionariosDto>> ListarFinalizadoresAsync();
    }
}