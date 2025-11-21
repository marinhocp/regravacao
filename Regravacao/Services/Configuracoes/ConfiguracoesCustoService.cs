using Regravacao.DTOs;
using Regravacao.Repositories.Configuracoes; // Depende da Interface do Repositório
using System;
using System.Threading.Tasks;

namespace Regravacao.Services.Configuracoes
{
    public class ConfiguracoesCustoService : IConfiguracoesCustoService
    {
        private readonly IConfiguracoesCustoRepository _repository;

        public ConfiguracoesCustoService(IConfiguracoesCustoRepository repository)
        {
            _repository = repository;
        }

        public async Task<ConfiguracoesCustoDto?> ObterConfiguracoesCustoAsync()
        {
            return await _repository.ObterAsync();
        }

        public async Task AtualizarConfiguracoesCustoAsync(ConfiguracoesCustoDto dto)
        {
            // Exemplo de Lógica de Negócio
            if (dto.MargemCorte < 0)
            {
                throw new ArgumentException("A Margem de Corte não pode ser negativa.");
            }

            await _repository.AtualizarAsync(dto);
        }
    }
}