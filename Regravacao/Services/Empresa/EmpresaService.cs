
using Regravacao.DTOs;
using Regravacao.Repositories.Empresa;

namespace Regravacao.Services.Empresa
{
    public class EmpresaService : IEmpresaService
    {
        private readonly IEmpresaRepository _repository;

        public EmpresaService(IEmpresaRepository repository) 
        {
            _repository = repository;
        }

        public async Task<List<EmpresaDto>> ObterEmpresasAtivasAsync()
        {
            return await _repository.ListarAtivasAsync();
        }
    }
}