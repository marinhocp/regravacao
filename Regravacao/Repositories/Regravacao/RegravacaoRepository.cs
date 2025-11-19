using System.Text.Json;
using Supabase;
using Regravacao.Models;
using Regravacao.DTOs;

namespace Regravacao.Repositories.Regravacao
{
    public class RegravacaoRepository : IRegravacaoRepository
    {
        private readonly Client _supabase;

        public RegravacaoRepository(Client supabase)
        {
            _supabase = supabase;
        }

        public async Task<int> InserirRegravacao(InserirRegravacaoDto dados)
        {
            var parametros = new Dictionary<string, object>
            {
                { "p_requerimento_atual", dados.RequerimentoAtual },
                { "p_requerimento_novo", dados.RequerimentoNovo },
                { "p_descricao_arte", dados.DescricaoArte },
                { "p_versao", dados.Versao },
                { "p_id_quem_finalizou", dados.IdQuemFinalizou },
                { "p_id_conferente", dados.IdConferente },
                { "p_id_solicitante", dados.IdSolicitante },
                { "p_id_enviar_para", dados.IdEnviarPara },
                { "p_id_cobrar_de_quem", dados.IdCobrarDeQuem },
                { "p_id_motivo_principal", dados.IdMotivoPrincipal },
                { "p_qtde_placas", dados.QtdePlacas },
                { "p_id_prioridade", dados.IdPrioridade },
                { "p_id_status", dados.IdStatus },
                { "p_data_cadastro", dados.DataCadastro },
                { "p_thumbnail", dados.Thumbnail },
                { "p_observacoes", dados.Observacoes },
                { "p_id_material", dados.IdMaterial },
                { "p_motivos_erros", dados.MotivosErrosIds },
                { "p_id_cor_1", dados.Cores[0].IdCor },
                { "p_largura_1", dados.Cores[0].Largura },
                { "p_comprimento_1", dados.Cores[0].Comprimento },
                { "p_custo_estimado_1", dados.Cores[0].CustoEstimado },
                { "p_id_cor_2", dados.Cores.Count > 1 ? dados.Cores[1].IdCor : 0 },
                { "p_largura_2", dados.Cores.Count > 1 ? dados.Cores[1].Largura : 0 },
                { "p_comprimento_2", dados.Cores.Count > 1 ? dados.Cores[1].Comprimento : 0 },
                { "p_custo_estimado_2", dados.Cores.Count > 1 ? dados.Cores[1].CustoEstimado : 0 }
            };

            var response = await _supabase.Rpc("sp_inserir_regravacao", parametros);
            return JsonSerializer.Deserialize<int>(response.Content);
        }

        public async Task<List<RegravacaoClicheModel>> ListarRegravacoes(
            string req = null,
            int? idSolicitante = null,
            int? idFinalizado = null,
            int? idConferente = null,
            int? idEnviarPara = null,
            int? idStatus = null,
            int? idCobrarDeQuem = null,
            int? idMotivoPrincipal = null,
            short? idMaterial = null,
            DateTime? dataIni = null,
            DateTime? dataFim = null)
        {
            var parametros = new Dictionary<string, object>
            {
                { "p_req", req },
                { "p_id_solicitante", idSolicitante },
                { "p_id_finalizado", idFinalizado },
                { "p_id_conferente", idConferente },
                { "p_id_enviar_para", idEnviarPara },
                { "p_id_status", idStatus },
                { "p_id_cobrar_de_quem", idCobrarDeQuem },
                { "p_id_motivo_principal", idMotivoPrincipal },
                { "p_id_material", idMaterial },
                { "p_data_ini", dataIni },
                { "p_data_fim", dataFim }
            };

            Supabase.Postgrest.Responses.BaseResponse response = await _supabase.Rpc("sp_listar_regravacoes", parametros);
            List<RegravacaoClicheModel>? regravacoes = JsonSerializer.Deserialize<List<RegravacaoClicheModel>>(response.Content);

            return regravacoes ?? [];
        }

        public async Task<EstatisticasRegravacaoModel> ObterEstatisticas(
            string req = null,
            int? idSolicitante = null,
            int? idFinalizado = null,
            int? idConferente = null,
            int? idEnviarPara = null,
            int? idStatus = null,
            int? idCobrarDeQuem = null,
            int? idMotivoPrincipal = null,
            short? idMaterial = null,
            DateTime? dataIni = null,
            DateTime? dataFim = null)
        {
            var parametros = new Dictionary<string, object>
            {
                { "p_req", req },
                { "p_id_solicitante", idSolicitante },
                { "p_id_finalizado", idFinalizado },
                { "p_id_conferente", idConferente },
                { "p_id_enviar_para", idEnviarPara },
                { "p_id_status", idStatus },
                { "p_id_cobrar_de_quem", idCobrarDeQuem },
                { "p_id_motivo_principal", idMotivoPrincipal },
                { "p_id_material", idMaterial },
                { "p_data_ini", dataIni },
                { "p_data_fim", dataFim }
            };

            Supabase.Postgrest.Responses.BaseResponse response = await _supabase.Rpc("sp_obter_estatisticas_regravacao", parametros);
            EstatisticasRegravacaoModel? resultado = JsonSerializer.Deserialize<EstatisticasRegravacaoModel>(response.Content);

            return resultado;
        }
    }
}
