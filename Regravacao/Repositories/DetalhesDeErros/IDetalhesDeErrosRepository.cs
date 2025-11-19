using Regravacao.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Regravacao.Repositories.DetalhesDeErros
{
    public interface IDetalhesDeErrosRepository
    {
        /// Busca a lista completa de erros (Modelos) cadastrados no Supabase.
        Task<List<DetalhesDeErrosModel>> ListarTodosErrosAsync();

       Task<List<DetalhesDeErrosModel>> ListarErrosPorIdsDtoAsync(List<int> idsErros);
    }
}