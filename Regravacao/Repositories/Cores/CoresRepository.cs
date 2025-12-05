using Regravacao.DTOs;
using Regravacao.Repositories.Cores;
using Supabase;

namespace Regravacao.Repositories
{
    public class CoresRepository : ICoresRepository
    {
        private readonly Client _supabase;

        public CoresRepository(Client supabase)
        {
            _supabase = supabase ?? throw new ArgumentNullException(nameof(supabase));
        }

        public async Task<List<CoresDto>> ListarTodasAsync()
        {
            // Seleciona apenas as colunas que você usa para a UI (pode adicionar paleta, rgb, cmyk se quiser)
            string colunas = "id_cor, paleta, nome_cor, codigo_hexadecimal, codigo_rgb, codigo_cmyk";

            var resposta = await _supabase
                .From<CoresDto>()
                .Select(colunas)
                .Limit(4000) // limite seguro
                .Get();

            if (!resposta.ResponseMessage.IsSuccessStatusCode)
            {
                throw new Exception($"Erro na API Supabase (cores): {resposta.ResponseMessage.ReasonPhrase}");
            }

            return resposta.Models.ToList();
        }
        
        // NOVO: Busca as cores que começam com o termo digitado.
        public async Task<List<CoresDto>> BuscarCoresPorNomeAsync(string termo)
        {
            string colunas = "id_cor, paleta, nome_cor, codigo_hexadecimal, codigo_rgb, codigo_cmyk";
            
            // Usamos ILIKE (case-insensitive) e '%' no final para busca "começando com"
            var resposta = await _supabase
                .From<CoresDto>()
                .Select(colunas)
                .Filter("nome_cor", Supabase.Postgrest.Constants.Operator.ILike, $"{termo}%")
                .Limit(50) // Limita os resultados para não sobrecarregar
                .Get();

            if (!resposta.ResponseMessage.IsSuccessStatusCode)
            {
                throw new Exception($"Erro na API Supabase (cores - busca): {resposta.ResponseMessage.ReasonPhrase}");
            }

            return resposta.Models.ToList();
        }
    }
}