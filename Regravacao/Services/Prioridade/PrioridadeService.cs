using System.Collections.Generic;
using System.Threading.Tasks;
using Regravacao.DTOs;
using Regravacao.Repositories.Prioridade;

namespace Regravacao.Services.Prioridade
{
    public class PrioridadeService : IPrioridadeService
    {
        private readonly IPrioridadeRepository _repository;

        public PrioridadeService(IPrioridadeRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<PrioridadeDto>> ObterTodasPrioridadesAsync()
        {
            return await _repository.ListarTodosAsync();
        }
    }
}