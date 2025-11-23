using Regravacao.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Regravacao.Repositories.Empresa
{
    public interface IEmpresaRepository
    {
        Task<List<EmpresaDto>> ListarAtivasAsync();
    }
}