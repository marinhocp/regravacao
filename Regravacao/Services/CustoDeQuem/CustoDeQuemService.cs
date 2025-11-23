using Regravacao.DTOs;
using Regravacao.Repositories.CustoDeQuem;
using Regravacao.Repositories.Empresa;

namespace Regravacao.Services.CustoDeQuem
{
    public class CustoDeQuemService : ICustoDeQuemService
    {
        private readonly ICustoDeQuemRepository _repository;

        public CustoDeQuemService(ICustoDeQuemRepository repository) 
        {
            _repository = repository;
        }

        public async Task<List<EmpresaDto>> ObterEmpresasAtivasAsync()
        {
            return await _repository.ListarAtivasAsync();
        }
    }
}