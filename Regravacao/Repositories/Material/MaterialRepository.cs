// Exemplo em Regravacao.Repositories.Material.Impl
using Regravacao.Models;

public class MaterialRepository : IMaterialRepository
{
    private readonly Supabase.Client _supabase;

    public MaterialRepository(Supabase.Client supabase)
    {
        _supabase = supabase;
    }

    public async Task<List<MaterialDto>> ListarTodosAsync()
    {
        var resposta = await _supabase
            .From<MaterialDto>()
            .Select("id_material, material")
            .Get();

        // O repositório trata a resposta da API, o serviço trata a lógica de negócio (se houver)
        if (!resposta.ResponseMessage.IsSuccessStatusCode)
        {
            throw new Exception($"Erro de API no repositório de materiais: {resposta.ResponseMessage.ReasonPhrase}");
        }
        return resposta.Models;
    }
}