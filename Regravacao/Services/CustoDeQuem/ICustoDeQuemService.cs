using Regravacao.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Regravacao.Services.CustoDeQuem
{
    public interface ICustoDeQuemService
    {
        Task<List<EmpresaDto>> ObterEmpresasAtivasAsync();
    }
}