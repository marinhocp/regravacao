using Regravacao.DTOs;
using Regravacao.Models;

namespace Regravacao.Repositories
{
    public interface IRegravacaoRepository
    {
        // 🎯 Função para inserção via RPC (Stored Procedure)
        Task<int> InserirRegravacao(InserirRegravacaoDto dados);

        // Funções de listagem
        Task<List<RegravacaoClicheModel>> ListarRegravacoes(
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
            DateTime? dataFim = null);

        // Função de estatísticas
        Task<EstatisticasRegravacaoModel> ObterEstatisticas(
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
            DateTime? dataFim = null);
    }
}