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
            // Busca todos os campos da tabela TblCores (mapeando para CoresDto)
            var resposta = await _supabase
                .From<CoresDto>()
                .Select("*") // Seleciona todos os campos definidos no DTO
                .Get();

            if (!resposta.ResponseMessage.IsSuccessStatusCode)
            {
                throw new Exception($"Erro de API no repositório de cores: {resposta.ResponseMessage.ReasonPhrase}");
            }

            // Os 2300 itens são retornados aqui
            return resposta.Models;
        }
    }
}