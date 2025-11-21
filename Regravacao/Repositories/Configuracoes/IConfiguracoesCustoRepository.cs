using Regravacao.DTOs;
using System.Threading.Tasks;

namespace Regravacao.Repositories.Configuracoes
{
    // Define o contrato para operações de CRUD de configurações.
    public interface IConfiguracoesCustoRepository
    {
        Task<ConfiguracoesCustoDto?> ObterAsync();
        Task AtualizarAsync(ConfiguracoesCustoDto dto);
    }
}