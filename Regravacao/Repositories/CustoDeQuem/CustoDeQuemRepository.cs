using Regravacao.DTOs;

namespace Regravacao.Repositories.CustoDeQuem
{
    public class CustoDeQuemRepository : ICustoDeQuemRepository
    {
        private readonly Supabase.Client _client;

        public CustoDeQuemRepository(Supabase.Client client)
        {
            _client = client;
        }

        public async Task<List<EmpresaDto>> ListarAtivasAsync()
        {
            var response = await _client.From<EmpresaDto>()
                .Where(e => e.IdStatus == 1)
                .Get();

            return response.Models;
        }
    }
}