using Regravacao.Models;
using System.Threading.Tasks;

namespace Regravacao.Repositories.Cores
{
    public interface ICoresRepository
    {
        Task<CoresModel?> GetCorByPartialNameAsync(string termoPesquisa);
    }
}