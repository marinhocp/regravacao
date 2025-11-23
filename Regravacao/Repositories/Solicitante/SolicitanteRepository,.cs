using Regravacao.DTOs;
using Supabase;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace Regravacao.Repositories.Solicitante
{
    public class SolicitanteRepository : ISolicitanteRepository
    {
        private readonly Client _supabase;

        public SolicitanteRepository(Client supabase)
        {
            _supabase = supabase;
        }

        public async Task<List<FuncionariosDto>> ListarPorCargosAsync(List<int> idsCargos)
        {

            var resposta = await _supabase
                .From<FuncionariosDto>()
                .Select("id_funcionario, nome, id_cargo")
                .Filter("id_cargo", Supabase.Postgrest.Constants.Operator.In, idsCargos)
                .Order("nome", Supabase.Postgrest.Constants.Ordering.Ascending)
                .Get();

            if (!resposta.ResponseMessage.IsSuccessStatusCode)
            {
                throw new Exception($"Erro de API no repositório de conferentes: {resposta.ResponseMessage.ReasonPhrase}");
            }
            return resposta.Models;
        }
    }
}