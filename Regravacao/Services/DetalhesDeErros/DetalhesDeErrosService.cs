using Regravacao.DTOs;
using Regravacao.Repositories.DetalhesDeErros;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Regravacao.Services.DetalhesDeErros
{
    public class DetalhesDeErrosService : IDetalhesDeErrosService
    {
        private readonly IDetalhesDeErrosRepository _repository;

        public DetalhesDeErrosService(IDetalhesDeErrosRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<DetalhesDeErrosDto>> ListarTodosErrosDtoAsync()
        {
            var models = await _repository.ListarTodosErrosAsync();

            // Simulação de Mapeamento (Model -> DTO)
            return models.Select(m => new DetalhesDeErrosDto
            {
                IdDetalhesErros = m.IdDetalhesErros,
                DescricaoErro = m.DescricaoErro
                // Mapeie outros campos conforme necessário
            }).ToList();
        }

        // ✅ Implementação do método que o FrmMain precisa
        public async Task<List<DetalhesDeErrosDto>> ListarErrosPorIdsDtoAsync(List<int> idsErros)
        {
            var models = await _repository.ListarErrosPorIdsDtoAsync(idsErros);

            // Simulação de Mapeamento (Model -> DTO)
            return models.Select(m => new DetalhesDeErrosDto
            {
                IdDetalhesErros = m.IdDetalhesErros,
                DescricaoErro = m.DescricaoErro
                // Mapeie outros campos conforme necessário
            }).ToList();
        }
    }
}