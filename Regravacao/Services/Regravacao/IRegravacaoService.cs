using Regravacao.DTOs;
using System.Threading.Tasks;

namespace Regravacao.Services.Regravacao
{
    public interface IRegravacaoService
    {
        Task<int> InserirAsync(RegravacaoInserirDto dto);
    }
}
