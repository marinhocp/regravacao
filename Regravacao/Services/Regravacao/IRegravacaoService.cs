using Regravacao.DTOs;
using Regravacao.Models;

namespace Regravacao.Services.Regravacao
{
    public interface IRegravacaoService
    {
        /// Cria uma nova solicitação de regravação no banco de dados.
        Task<int> CriarRegravacao(InserirRegravacaoDto dados);

        /// Busca regravações conforme os filtros informados.
        Task<List<RegravacaoClicheModel>> BuscarRegravacoes(
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

        /// Retorna estatísticas de regravações conforme os filtros aplicados.
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