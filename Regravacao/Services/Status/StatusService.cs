using System.Collections.Generic;
using System.Threading.Tasks;
using Regravacao.DTOs;
using Regravacao.Repositories.Status;

namespace Regravacao.Services.Status
{
    public class StatusService : IStatusService
    {
        private readonly IStatusRepository _repository;

        public StatusService(IStatusRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<StatusDto>> ObterTodosStatusAsync()
        {
            return await _repository.ListarTodosAsync();
        }
    }
}