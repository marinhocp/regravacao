using Regravacao.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Regravacao.Services.DetalhesDeErros
{
    public interface IDetalhesDeErrosService
    {
        Task<List<DetalhesDeErrosDto>> ListarTodosErrosDtoAsync();

        Task<List<DetalhesDeErrosDto>> ListarErrosPorIdsDtoAsync(List<int> idsErros);
    }
}