using System.Collections.Generic;
using System.Threading.Tasks;
using Regravacao.DTOs;
using Supabase;

namespace Regravacao.Repositories.Prioridade
{
    public class PrioridadeRepository : IPrioridadeRepository
    {
        private readonly Supabase.Client _client;

        public PrioridadeRepository(Supabase.Client client)
        {
            _client = client;
        }

        public async Task<List<PrioridadeDto>> ListarTodosAsync()
        {
            var response = await _client.From<PrioridadeDto>()
                .Get();

            return response.Models;
        }
    }
}