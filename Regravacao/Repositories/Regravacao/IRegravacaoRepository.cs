using Regravacao.DTOs;
using System.Threading.Tasks;

namespace Regravacao.Repositories.Regravacao
{
    public interface IRegravacaoRepository
    {
        Task<int> InserirRegravacaoAsync(RegravacaoInserirDto dto);
    }
}
