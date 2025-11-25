using Regravacao.DTOs;

namespace Regravacao.Services.Cores
{
    public class CoresService : ICoresService
    {
        private readonly ICoresRepository _repository;

        public CoresService(ICoresRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<CoresDto>> ListarCoresAsync()
        {
            // Aqui, você pode adicionar lógica de cache ou validação antes de chamar o Repositório
            return await _repository.ListarTodasAsync();
        }
    }
}