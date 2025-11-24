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
            // 1. Serializa a lista de Cores para string JSON (para o parâmetro p_cores JSONB)
            string coresJson = JsonSerializer.Serialize(dados.Cores);

            // 2. Trata o valor NULL para a lista de motivos (p_motivos integer[])
            object motivosValue = dados.MotivosErrosIds != null && dados.MotivosErrosIds.Count > 0
                                  ? (object)dados.MotivosErrosIds
                                  : DBNull.Value;

            // 3. Trata valores nulos para campos opcionais no DB
            object reqNovoValue = dados.RequerimentoNovo ?? DBNull.Value.ToString();
            object cobradorValue = dados.IdCobrarDeQuem.HasValue ? (object)dados.IdCobrarDeQuem.Value : DBNull.Value;
            object observacoesValue = dados.Observacoes ?? DBNull.Value.ToString();
            object thumbnailValue = dados.Thumbnail ?? DBNull.Value.ToString();

            // A data de cadastro pode ser NULL (se o DB tiver DEFAULT), mas o SP exige um valor.
            // Usamos a data fornecida ou a data atual (UTC é recomendada para DBs).
            DateTime dataCadastro = dados.DataCadastro ?? DateTime.UtcNow;


            var parametros = new Dictionary<string, object>
            {
                // Parâmetros Simples (Mapeando para os 'p_' da sua SP)
                { "p_requerimento_atual", dados.RequerimentoAtual },
                { "p_requerimento_novo", reqNovoValue },
                { "p_descricao_arte", dados.DescricaoArte },
                { "p_versao", dados.Versao },
                { "p_id_quem_finalizou", dados.IdQuemFinalizou },
                { "p_id_conferente", dados.IdConferente },
                { "p_id_solicitante", dados.IdSolicitante },
                { "p_id_enviar_para", dados.IdEnviarPara },
                { "p_id_cobrar_de_quem", cobradorValue },
                { "p_id_motivo_principal", dados.IdMotivoPrincipal },
                { "p_qtde_placas", dados.QtdePlacas },
                { "p_id_prioridade", dados.IdPrioridade },
                { "p_id_status", dados.IdStatus },
                
                // Conversão de data para formato SP (Timestamp)
                { "p_data_cadastro", dataCadastro }, 
                
                // Parâmetros Nullables (Textos/URLs)
                { "p_thumbnail", thumbnailValue },
                { "p_observacoes", observacoesValue },
                { "p_id_material", dados.IdMaterial }, // Não é nullable no seu DTO
                
                // Parâmetros Array/JSON (Tratados acima)
                { "p_motivos", motivosValue }, // Array de IDs (NULL ou List<int>)
                { "p_cores", coresJson }       // JSON string
            };

            // 4. Chamada RPC
            var response = await _supabase.Rpc("sp_inserir_regravacao", parametros);

            // 5. Retorna o ID de inserção (retornado pela sua SP)
            return JsonSerializer.Deserialize<int>(response.Content);
        }

        // ... Implementações de ListarRegravacoes e ObterEstatisticas ...

        public Task<List<RegravacaoClicheModel>> ListarRegravacoes(
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
            DateTime? dataFim = null) => throw new NotImplementedException();
        public Task<EstatisticasRegravacaoModel> ObterEstatisticas(
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
            DateTime? dataFim = null) => throw new NotImplementedException();
    }
}