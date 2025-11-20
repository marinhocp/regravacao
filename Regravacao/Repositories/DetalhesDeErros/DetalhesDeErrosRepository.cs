using Regravacao.Models;
using Supabase;
using System.Collections.Generic;
using System.Threading.Tasks;
using System; 

namespace Regravacao.Repositories.DetalhesDeErros
{
    public class DetalhesDeErrosRepository(Client supabase) : IDetalhesDeErrosRepository
    {
        private readonly Client _supabase = supabase;
        private const string ID_COLUNA_DB = "id_detalhes_erros";

        public async Task<List<DetalhesDeErrosModel>> ListarTodosErrosAsync()
        {
            var response = await _supabase.From<DetalhesDeErrosModel>()                
                .Select("*")
                .Get();

            if (!response.ResponseMessage.IsSuccessStatusCode)
            {
                throw new Exception($"Erro ao listar todos os detalhes dos erros: {response.ResponseMessage.ReasonPhrase}");
            }
            return response.Models;
        }

        
        public async Task<List<DetalhesDeErrosModel>> ListarErrosPorIdsDtoAsync(List<int> idsErros)
        {
            var response = await _supabase.From<DetalhesDeErrosModel>()
                
                .Filter(ID_COLUNA_DB, Supabase.Postgrest.Constants.Operator.In, idsErros)               
                .Select($"{ID_COLUNA_DB}, descricao_erro")
                .Get();
            
            if (!response.ResponseMessage.IsSuccessStatusCode)
            {
                throw new Exception($"Erro ao buscar detalhes dos erros por IDs: {response.ResponseMessage.ReasonPhrase}");
            }

            return response.Models;
        }
    }
}