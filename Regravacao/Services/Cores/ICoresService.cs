// Regravacao.Services.Cores.ICoresService

using Regravacao.Models;

public interface ICoresService
{
    // Método que receberá o nome digitado, fará a limpeza (ignorar "PANTONE")
    // e buscará o CoresModel correspondente exatamente no banco.
    Task<CoresModel?> BuscarCorPorNomeExatoProcessadoAsync(string nomeDigitado);
}