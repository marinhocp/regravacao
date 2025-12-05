using Regravacao.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Regravacao.Repositories.Funcionario
{
    public interface IFinalizadorRepository
    {
        Task<List<FuncionariosDto>> ListarPorCargoAsync(List<int> idsCargos);
    }
}