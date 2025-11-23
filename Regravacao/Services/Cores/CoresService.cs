using Regravacao.Models;
using Regravacao.Repositories.Cores;
using System.Threading.Tasks;

namespace Regravacao.Services.Cores
{
    public class CoresService : ICoresService
    {
        private readonly ICoresRepository _coresRepository;

        public CoresService(ICoresRepository coresRepository)
        {
            _coresRepository = coresRepository;
        }

        public async Task<CoresModel?> BuscarCorPorNomeParcialAsync(string termoPesquisa)
        {
            if (string.IsNullOrWhiteSpace(termoPesquisa))
            {
                return null;
            }

            return await _coresRepository.GetCorByPartialNameAsync(termoPesquisa);
        }
    }
}