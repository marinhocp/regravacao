using Regravacao.DTOs;

public interface ICoresService
{
    Task<List<CoresDto>> ListarCoresAsync();
}