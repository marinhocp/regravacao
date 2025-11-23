using Regravacao.DTOs;
using Regravacao.Repositories.Solicitante;

namespace Regravacao.Services.Solicitante
{
    public class SolicitanteService : ISolicitanteService
    {
        private readonly ISolicitanteRepository _repository;
        private static readonly List<int> IDS_CARGOS_CONFERENTE = new List<int> { 2, 3, 10 };

        public SolicitanteService(ISolicitanteRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<FuncionariosDto>> ListarSolicitanteAsync()
        {
            return await _repository.ListarPorCargosAsync(IDS_CARGOS_CONFERENTE);
        }
    }
}