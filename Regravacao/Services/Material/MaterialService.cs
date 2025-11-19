// Exemplo em Regravacao.Services.Material.Impl
using Regravacao.Models;

public class MaterialService : IMaterialService
{
    // ⚠️ Agora dependemos do Repositório, não diretamente do Supabase
    private readonly IMaterialRepository _repository;

    public MaterialService(IMaterialRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<MaterialDto>> ListarMateriaisAsync()
    {
        // Chama o Repositório. Se houver alguma regra de negócio (ex: filtrar por permissão), ela viria aqui.
        return await _repository.ListarTodosAsync();
    }
}