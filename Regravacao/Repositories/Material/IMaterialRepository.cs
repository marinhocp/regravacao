// Exemplo em Regravacao.Repositories.Material
using Regravacao.Models;

public interface IMaterialRepository
{
    // Retorna os DTOs diretamente do banco
    Task<List<MaterialDto>> ListarTodosAsync();
}