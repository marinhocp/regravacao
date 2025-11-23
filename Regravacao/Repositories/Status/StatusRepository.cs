using System.Collections.Generic;
using System.Threading.Tasks;
using Regravacao.DTOs;
using Supabase;

namespace Regravacao.Repositories.Status
{
    public class StatusRepository : IStatusRepository
    {
        private readonly Supabase.Client _client;

        public StatusRepository(Supabase.Client client)
        {
            _client = client;
        }

        public async Task<List<StatusDto>> ListarTodosAsync()
        {
            var response = await _client.From<StatusDto>()
                .Get();

            return response.Models;
        }
    }
}