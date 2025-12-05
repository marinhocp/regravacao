using Regravacao.DTOs;
using Supabase;
using Regravacao.Repositories.Funcionario;

namespace Regravacao.Repositories.Finalizador
{
    public class FinalizadorRepository : IFinalizadorRepository
    {
        private readonly Client _supabase;

        public FinalizadorRepository(Client supabase)
        {
            _supabase = supabase;
        }

        public async Task<List<FuncionariosDto>> ListarPorCargoAsync(List<int> idsCargos)
        {
            var resposta = await _supabase
                .From<FuncionariosDto>()
                .Select("id_funcionario, nome, id_cargo")
               
                .Filter("id_cargo", Supabase.Postgrest.Constants.Operator.In, idsCargos)

                .Order("nome", Supabase.Postgrest.Constants.Ordering.Ascending)
                .Get();

            if (!resposta.ResponseMessage.IsSuccessStatusCode)
            {
                throw new Exception($"Erro de API no repositório de funcionários: {resposta.ResponseMessage.ReasonPhrase}");
            }
            return resposta.Models;
        }
    }
}