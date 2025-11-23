using Regravacao.Models;
using System.Threading.Tasks;
using Supabase;
using System.Linq;
using static Supabase.Postgrest.Constants.Operator;

namespace Regravacao.Repositories.Cores
{
    public class CoresRepository : ICoresRepository
    {
        private readonly Supabase.Client _supabaseClient;

        public CoresRepository(Supabase.Client supabaseClient)
        {
            _supabaseClient = supabaseClient;
        }

        public async Task<CoresModel?> GetCorByPartialNameAsync(string termoPesquisa)
        {
            if (string.IsNullOrWhiteSpace(termoPesquisa))
            {
                return null;
            }

            var termoNormalizado = termoPesquisa.Trim();

            var response = await _supabaseClient.From<CoresModel>()
                // Acesso direto ao ILike sem prefixo
                .Filter(c => c.NomeCor, ILike, $"%{termoNormalizado}%")
                .Limit(1)
                .Get();

            return response.Models.FirstOrDefault();
        }
    }
}