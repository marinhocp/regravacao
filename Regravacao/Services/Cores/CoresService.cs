using Regravacao.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Regravacao.Services.Cores
{
    public class CoresService : ICoresService
    {
        private readonly ICoresCacheService _cacheService;
        public CoresService(ICoresCacheService cacheService)
        {
            _cacheService = cacheService;
        }

        public async Task<List<CoresDto>> ListarCoresAsync()
        {
            return await _cacheService.GetCoresCachedAsync();
        }
    }
}
