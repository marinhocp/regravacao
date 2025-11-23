using Regravacao.Models;
using System.Threading.Tasks;

namespace Regravacao.Services.Cores
{
    public interface ICoresService
    {
        Task<CoresModel?> BuscarCorPorNomeParcialAsync(string termoPesquisa);
    }
}