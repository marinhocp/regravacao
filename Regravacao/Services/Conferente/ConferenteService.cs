using Regravacao.DTOs;
using Regravacao.Repositories.Conferente; // Importar o namespace da interface
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Regravacao.Services.Conferente
{
    public class ConferenteService : IConferenteService
    {
        private readonly IConferenteRepository _repository;

        // ✅ Regra de Negócio: Os IDs que representam um Conferente
        private static readonly List<int> IDS_CARGOS_CONFERENTE = new List<int> { 2, 4, 5 };

        public ConferenteService(IConferenteRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<FuncionariosDto>> ListarConferentesAsync()
        {
            // Chama o repositório passando a lista de IDs de cargo
            return await _repository.ListarPorCargosAsync(IDS_CARGOS_CONFERENTE);
        }
    }
}