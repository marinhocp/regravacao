using Regravacao.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;
using System; // Adicionado para suportar DateTime?

namespace Regravacao.Repositories.Regravacao
{
    public interface IRegravacaoQueryRepository
    {
        // Método de busca avançada (mantém o DTO complexo)
        Task<List<RegravacaoConsultaDto>> BuscarRegravacoesAvancadasAsync(
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
        );

        // 🌟 CORRIGIDO: Método de busca simples (agora retorna o DTO simplificado)
        Task<List<RegravacaoConsultaSimplesDto>> GetUltimosRegistrosAsync(int quantidade);
    }
}