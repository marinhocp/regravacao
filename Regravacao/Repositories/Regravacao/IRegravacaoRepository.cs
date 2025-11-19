using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Regravacao.Models;
using Regravacao.DTOs;

namespace Regravacao.Repositories
{
    public interface IRegravacaoRepository
    {
        Task<int> InserirRegravacao(InserirRegravacaoDto dados);

        Task<List<Models.RegravacaoClicheModel>> ListarRegravacoes(
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
