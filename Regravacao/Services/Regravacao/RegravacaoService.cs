using Regravacao.DTOs;
using Regravacao.Models;
using Regravacao.Repositories;
using Regravacao.Services.Regravacao;
using Supabase;

public class RegravacaoService : IRegravacaoService
{
    private readonly IRegravacaoRepository _repository;

    public RegravacaoService(IRegravacaoRepository repository)
    {
        _repository = repository;
    }

    public async Task<int> CriarRegravacao(InserirRegravacaoDto dados)
    {
        // Validação de Negócio (Se for o caso)
        if (string.IsNullOrWhiteSpace(dados.RequerimentoAtual))
            throw new ArgumentException("O campo 'Requerimento Atual' é obrigatório.");

        if (dados.Cores == null || dados.Cores.Count == 0)
            throw new ArgumentException("Pelo menos uma cor deve ser informada.");

        if (dados.Cores.Count > 8)
            throw new ArgumentException("Máximo de 8 cores permitidas.");

        // Chama o repositório para executar o RPC
        return await _repository.InserirRegravacao(dados);
    }

    // ... Implementações de BuscarRegravacoes e ObterEstatisticas
    public Task<List<RegravacaoClicheModel>> BuscarRegravacoes(
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