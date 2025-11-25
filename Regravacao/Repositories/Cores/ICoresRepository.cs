// Em: Regravacao.Repositories
using Regravacao.DTOs;

public interface ICoresRepository
{
    /// <summary>
    /// Retorna todas as cores da tabela TblCores de forma assíncrona.
    /// </summary>
    Task<List<CoresDto>> ListarTodasAsync();
}