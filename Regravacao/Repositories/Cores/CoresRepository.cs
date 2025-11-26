// Em: Regravacao.Repositories.Impl
using Regravacao.DTOs;
using Supabase;

namespace Regravacao.Repositories
{
    public class CoresRepository : ICoresRepository
    {
        private readonly Supabase.Client _supabase;

        public CoresRepository(Supabase.Client supabase)
        {
            _supabase = supabase;
        }

        public async Task<List<CoresDto>> ListarTodasAsync()
        {
            // String de seleção com apenas as colunas necessárias
            string colunas = "id_cor, nome_cor, codigo_hexadecimal";

            var resposta = await _supabase
                .From<CoresDto>()
                // ✅ Seleciona somente as colunas listadas
                .Select(colunas)
                .Limit(2000)
                .Get();

            if (!resposta.ResponseMessage.IsSuccessStatusCode)
            {
                throw new Exception($"Erro de API no repositório de cores: {resposta.ResponseMessage.ReasonPhrase}");
            }
            return resposta.Models.ToList();
        }
    }
}