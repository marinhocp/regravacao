using Regravacao.DTOs;
using Supabase;
using System.Text.Json;
using System.Threading.Tasks;

namespace Regravacao.Repositories.Regravacao
{
    public class RegravacaoRepository : IRegravacaoRepository
    {
        private readonly Client _client;

        public RegravacaoRepository(Client client)
        {
            _client = client;
        }

        public async Task<int> InserirRegravacaoAsync(RegravacaoInserirDto dto)
        {
            // O DTO que você enviou estava com o nome InserirRegravacaoDto e MotivosIds
            // Estou corrigindo os nomes dos parâmetros no repositório para os que você
            // usou no código anterior (RegravacaoInserirDto e IdsErrosSelecionados)

            // motivos = int[]?
            var motivos = dto.IdsErrosSelecionados?.ToArray();
            var parametros = new Dictionary<string, object?>
            {
                { "p_requerimento_atual", dto.RequerimentoAtual },
                { "p_requerimento_novo", dto.RequerimentoNovo },
                { "p_descricao_arte", dto.DescricaoArte },
                { "p_versao", dto.Versao },

                { "p_id_quem_finalizou", dto.IdQuemFinalizou },
                { "p_id_conferente", dto.IdConferente },
                { "p_id_solicitante", dto.IdSolicitante },
                { "p_id_enviar_para", dto.IdEnviarPara },

                // O DTO enviado usa IdCobrarDeQuem. Mantendo o nome do parâmetro
                { "p_id_cobrar_de_quem", dto.IdCustoDeQuem },
                { "p_id_motivo_principal", dto.IdMotivoPrincipal },

                { "p_qtde_placas", dto.QtdePlacas },
                { "p_id_prioridade", dto.IdPrioridade },
                { "p_id_status", dto.IdStatus },

                { "p_data_cadastro", dto.DataCadastro },
                { "p_thumbnail", dto.ThumbnailUrl },
                { "p_observacoes", dto.Observacoes },

                { "p_id_material", dto.IdMaterial },

                { "p_motivos", motivos },
                // ✅ Enviando como string JSON
                { "p_cores", dto.Cores }
            };

            var rpc = await _client.Rpc("sp_inserir_regravacao", parametros);

            using var jsonDoc = JsonDocument.Parse(rpc.Content);
            int idGerado = jsonDoc.RootElement.GetInt32();

            return idGerado;
        }
    }
}