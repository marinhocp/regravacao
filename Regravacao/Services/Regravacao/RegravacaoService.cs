using Regravacao.DTOs;
using Regravacao.Helpers;
using Regravacao.Models;
using Regravacao.Repositories;
using Regravacao.Services.Regravacao;
using Supabase;


public class RegravacaoService : IRegravacaoService
{
    private readonly IRegravacaoRepository _repository;
    private readonly Client _supabase;

    public RegravacaoService(IRegravacaoRepository repository, Client supabase)
    {
        _repository = repository;
        _supabase = supabase;
    }

    // ======================================================
    // ✅ LOGOUT COMPLETO (Remoto + Local + Memória)
    // ======================================================
    public async Task EfetuarLogoutAsync()
    {
        try
        {
            // 🔹 1. Logout remoto no Supabase (encerra a sessão ativa)
            await _supabase.Auth.SignOut();

            // 🔹 2. Limpa o arquivo local de sessão persistida
            SessaoHelper.LimparSessao();

            // 🔹 3. Reseta a sessão em memória
            try
            {
                await _supabase.Auth.SetSession(null, null);
            }
            catch
            {
                // Alguns SDKs podem lançar exceção, então ignoramos com segurança
            }

            Console.WriteLine("✅ Logout completo realizado com sucesso.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"⚠️ Erro ao efetuar logout: {ex.Message}");
        }
    }

    // ======================================================
    // ✅ CRIAR REGRAVAÇÃO
    // ======================================================
    public async Task<int> CriarRegravacao(InserirRegravacaoDto dados)
    {
        if (string.IsNullOrWhiteSpace(dados.RequerimentoAtual))
            throw new ArgumentException("O campo 'Requerimento Atual' é obrigatório.");

        if (dados.Cores == null || dados.Cores.Count == 0)
            throw new ArgumentException("Pelo menos uma cor deve ser informada.");

        if (dados.Cores.Count > 8)
            throw new ArgumentException("Máximo de 8 cores permitidas.");

        return await _repository.InserirRegravacao(dados);
    }

    // ======================================================
    // ✅ BUSCAR REGRAVAÇÕES
    // ======================================================
    public async Task<List<RegravacaoClicheModel>> BuscarRegravacoes(
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
        return await _repository.ListarRegravacoes(
            req,
            idSolicitante,
            idFinalizado,
            idConferente,
            idEnviarPara,
            idStatus,
            idCobrarDeQuem,
            idMotivoPrincipal,
            idMaterial,
            dataIni,
            dataFim
        );
    }

    // ======================================================
    // ✅ OBTER ESTATÍSTICAS DE REGRAVAÇÃO
    // ======================================================
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
        return await _repository.ObterEstatisticas(
            req,
            idSolicitante,
            idFinalizado,
            idConferente,
            idEnviarPara,
            idStatus,
            idCobrarDeQuem,
            idMotivoPrincipal,
            idMaterial,
            dataIni,
            dataFim
        );
    }
}