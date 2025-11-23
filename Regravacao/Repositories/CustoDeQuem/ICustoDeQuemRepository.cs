using Regravacao.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Regravacao.Repositories.CustoDeQuem
{
    public interface ICustoDeQuemRepository
    {
        Task<List<EmpresaDto>> ListarAtivasAsync();
    }
}