using Regravacao.Models;
using Supabase;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Regravacao.Repositories.DetalhesDeErros
{
    public class DetalhesDeErrosRepository(Client supabase) : IDetalhesDeErrosRepository
    {
        private readonly Client _supabase = supabase;

        public async Task<List<DetalhesDeErrosModel>> ListarTodosErrosAsync()
        {
            var response = await _supabase.From<DetalhesDeErrosModel>()
                .Select("*")
                .Get();

            return response.Models;
        }

        // ✅ Implementação da busca por IDs
        public async Task<List<DetalhesDeErrosModel>> ListarErrosPorIdsDtoAsync(List<int> idsErros)
        {
            var response = await _supabase.From<DetalhesDeErrosModel>()
                // Filtra onde a coluna IdDetalhesErros ESTÁ INCLUÍDA na lista de idsErros
                .Filter(nameof(DetalhesDeErrosModel.IdDetalhesErros), Supabase.Postgrest.Constants.Operator.In, idsErros)
                .Get();

            return response.Models;
        }
    }
}