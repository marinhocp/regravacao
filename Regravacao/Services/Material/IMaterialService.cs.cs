// Exemplo em Regravacao.Services.Material
using Regravacao.Models;

public interface IMaterialService
{
    // O método retorna apenas a lista de DTOs, sem a complexidade do Supabase Response.
    Task<List<MaterialDto>> ListarMateriaisAsync();
}