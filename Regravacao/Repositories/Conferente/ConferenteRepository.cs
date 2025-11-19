using Regravacao.DTOs;
using Supabase;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Regravacao.Repositories.Conferente;

namespace Regravacao.Repositories.Conferente.Impl
{
    public class ConferenteRepository : IConferenteRepository
    {
        private readonly Client _supabase;

        public ConferenteRepository(Client supabase)
        {
            _supabase = supabase;
        }

        public async Task<List<FuncionariosDto>> ListarPorCargosAsync(List<int> idsCargos)
        {
            // ❌ REMOVER: var idsCargosString = string.Join(",", idsCargos); 

            var resposta = await _supabase
                .From<FuncionariosDto>()
                .Select("id_funcionario, nome, id_cargo")

                // ✅ CORREÇÃO: Passar a lista 'idsCargos' (List<int>) diretamente
                // O SDK saberá como formatá-la internamente para o operador 'In'
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