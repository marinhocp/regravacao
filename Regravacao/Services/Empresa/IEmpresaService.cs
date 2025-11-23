using Regravacao.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Regravacao.Services.Empresa
{
    public interface IEmpresaService
    {
        Task<List<EmpresaDto>> ObterEmpresasAtivasAsync();
    }
}