using Regravacao.DTOs;

namespace Regravacao.Repositories.Configuracoes
{
    // Lógica de comunicação direta com o Supabase/Postgrest
    public class ConfiguracoesCustoRepository : IConfiguracoesCustoRepository
    {
        private readonly Supabase.Client _client;

        public ConfiguracoesCustoRepository(Supabase.Client client)
        {
            _client = client;
        }

        public async Task<ConfiguracoesCustoDto?> ObterAsync()
        {
            // Assume que a tabela TblConfiguracoesCusto tem apenas uma linha.
            var response = await _client.From<ConfiguracoesCustoDto>()
                .Get();

            // Retorna o único registro ou null.
            return response.Models.FirstOrDefault();
        }

        public async Task AtualizarAsync(ConfiguracoesCustoDto dto)
        {
            // O [PrimaryKey] no DTO garante que o Supabase faça o UPDATE correto.
            await _client.From<ConfiguracoesCustoDto>()
                .Update(dto);
        }
    }
}