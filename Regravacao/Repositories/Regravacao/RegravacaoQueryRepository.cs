using Regravacao.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text.Json;
using System.Linq;
using Supabase;
using System;

namespace Regravacao.Repositories.Regravacao
{
    public class RegravacaoQueryRepository : IRegravacaoQueryRepository
    {
        private readonly Supabase.Client _client;

        private readonly JsonSerializerOptions _jsonOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        public RegravacaoQueryRepository(Supabase.Client client)
        {
            _client = client;
        }

        // Implementação do BuscarRegravacoesAvancadasAsync (mantida para o DTO complexo)
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
            // [Mantenha aqui sua implementação RPC existente para 'busca_regravacoes_avancada' e RegravacaoConsultaDto]
            // Se você não tem o código agora, use esta exceção temporária:
            throw new NotImplementedException("Implementação da Busca Avançada deve chamar a function SQL com todos os filtros.");
        }

        // Implementação do GetUltimosRegistrosAsync (corrigida para DTO simples e nova function SQL)
        public async Task<List<RegravacaoConsultaSimplesDto>> GetUltimosRegistrosAsync(int quantidade)
        {
            // Monta os parâmetros necessários para a função 'busca_regravacoes_simples'.
            // Como esta é a busca inicial (Top N), passamos NULL para todos os filtros da função SQL
            // e contamos com o ORDER BY e o Take(quantidade) no C#.
            var parametros = new Dictionary<string, object?>
            {
                { "p_req", null },
                { "p_id_solicitante", null },
                { "p_id_finalizado", null },
                { "p_id_conferente", null },
                { "p_id_enviar_para", null },
                { "p_id_status", null },
                { "p_id_cobrar_de_quem", null },
                { "p_id_motivo_principal", null },
                { "p_id_material", null },
                { "p_data_ini", null },
                { "p_data_fim", null }
            };

            // 🚨 Chamada RPC para a function SQL corrigida
            var rpcResponse = await _client.Rpc("busca_regravacoes_simples", parametros);

            if (rpcResponse.Content == null)
            {
                return new List<RegravacaoConsultaSimplesDto>();
            }

            // Desserializa para o novo DTO simplificado
            var resultado = JsonSerializer.Deserialize<List<RegravacaoConsultaSimplesDto>>(rpcResponse.Content, _jsonOptions);

            // Aplica a limitação TOP N no C# (pois a função SQL não tem o parâmetro p_limite neste formato)
            return (resultado ?? new List<RegravacaoConsultaSimplesDto>()).Take(quantidade).ToList();
        }
    }
}