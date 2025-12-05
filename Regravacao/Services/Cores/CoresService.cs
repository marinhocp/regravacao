using Regravacao.DTOs;
using Regravacao.Repositories.Cores;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Regravacao.Services.Cores
{
    public class CoresService : ICoresService
    {
        private readonly ICoresCacheService _cacheService;
        private readonly ICoresRepository _coresRepository; // Adicione o repositório

        // Atualize o construtor para receber o repositório
        public CoresService(ICoresCacheService cacheService, ICoresRepository coresRepository)
        {
            _cacheService = cacheService;
            _coresRepository = coresRepository; // Armazene o repositório
        }

        public async Task<List<CoresDto>> ListarCoresAsync()
        {
            // Este método ainda existe para quem precisar da lista completa (ex: exportação)
            return await _cacheService.GetCoresCachedAsync();
        }

        // NOVO: Passa a busca diretamente para o repositório (que busca no Supabase)
        public async Task<List<CoresDto>> BuscarCoresPorNomeAsync(string termo)
        {
            return await _coresRepository.BuscarCoresPorNomeAsync(termo);
        }
    }
}