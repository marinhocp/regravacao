using Regravacao.DTOs;
using System.Threading.Tasks;

namespace Regravacao.Services.Configuracoes
{
    // Define o contrato de serviço (regras de negócio)
    public interface IConfiguracoesCustoService
    {
        Task<ConfiguracoesCustoDto?> ObterConfiguracoesCustoAsync();
        Task AtualizarConfiguracoesCustoAsync(ConfiguracoesCustoDto dto);
    }
}