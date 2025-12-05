using Regravacao.DTOs;
using Regravacao.Repositories.Regravacao;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace Regravacao.Services.Regravacao
{
    public class RegravacaoQueryService : IRegravacaoQueryService
    {
        private readonly IRegravacaoQueryRepository _repo;

        public RegravacaoQueryService(IRegravacaoQueryRepository repo)
        {
            _repo = repo;
        }

        // 1. Implementação da Busca Avançada (Retorna DTO complexo)
        public async Task<List<RegravacaoConsultaDto>> BuscarRegravacoesAvancadasAsync(
            string? p_req,
            int? p_id_solicitante,
            int? p_id_finalizado,
            int? p_id_conferente,
            int? p_id_enviar_para,
            int? p_id_status,
            int? p_id_cobrar_de_quem,
            int? p_id_motivo_principal,
            short? p_id_material,
            DateTime? p_data_ini,
            DateTime? p_data_fim
        )
        {
            return await _repo.BuscarRegravacoesAvancadasAsync(
                p_req, p_id_solicitante, p_id_finalizado, p_id_conferente,
                p_id_enviar_para, p_id_status, p_id_cobrar_de_quem, p_id_motivo_principal,
                p_id_material, p_data_ini, p_data_fim
            );
        }

        // 2. 🌟 CORREÇÃO FINAL: Implementação da Busca Simples (Retorna DTO Simples)
        public async Task<List<RegravacaoConsultaSimplesDto>> GetUltimosRegistrosAsync(int quantidade)
        {
            // O tipo de retorno do método agora corresponde ao tipo de retorno do repositório, 
            // satisfazendo a interface.
            return await _repo.GetUltimosRegistrosAsync(quantidade);
        }
    }
}