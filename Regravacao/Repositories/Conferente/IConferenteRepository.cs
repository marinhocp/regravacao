using Regravacao.DTOs;

namespace Regravacao.Repositories.Conferente
{
    public interface IConferenteRepository
    {
        // 💡 Assinatura atualizada para aceitar uma lista de IDs de Cargo
        Task<List<FuncionariosDto>> ListarPorCargosAsync(List<int> idsCargos);
    }
}