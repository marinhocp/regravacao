using System.Collections.Generic;
using System.Threading.Tasks;
using Regravacao.DTOs;
using Supabase;

namespace Regravacao.Repositories.MotivosPrincipais
{
    public class MotivosPrincipaisRepository : IMotivosPrincipaisRepository
    {
        private readonly Supabase.Client _client;

        public MotivosPrincipaisRepository(Supabase.Client client)
        {
            _client = client;
        }

        public async Task<List<MotivosPrincipaisDto>> ListarTodosAsync()
        {
            // Busca todos os motivos principais (sem filtro de status, assumindo que todos são válidos)
            var response = await _client.From<MotivosPrincipaisDto>()
                .Get();

            return response.Models;
        }
    }
}