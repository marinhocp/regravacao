using Regravacao.DTOs;
using Supabase;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace Regravacao.Repositories.Funcionario.Impl
{
    public class FuncionarioRepository : IFuncionarioRepository
    {
        private readonly Client _supabase;

        public FuncionarioRepository(Client supabase)
        {
            _supabase = supabase;
        }

        public async Task<List<FuncionariosDto>> ListarPorCargoAsync(int idCargo)
        {
            var resposta = await _supabase
                .From<FuncionariosDto>()
                .Select("id_funcionario, nome, id_cargo")
                // ✅ Filtro correto
                .Filter("id_cargo", Supabase.Postgrest.Constants.Operator.Equals, idCargo)

                // ✅ Ordenação correta, com a sintaxe completa
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