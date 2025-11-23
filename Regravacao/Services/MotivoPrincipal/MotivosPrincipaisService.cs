using System.Collections.Generic;
using System.Threading.Tasks;
using Regravacao.DTOs;
using Regravacao.Repositories.MotivosPrincipais;

namespace Regravacao.Services.MotivosPrincipais
{
    public class MotivosPrincipaisService : IMotivosPrincipaisService
    {
        private readonly IMotivosPrincipaisRepository _repository;

        public MotivosPrincipaisService(IMotivosPrincipaisRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<MotivosPrincipaisDto>> ObterTodosMotivosAsync()
        {
            return await _repository.ListarTodosAsync();
        }
    }
}