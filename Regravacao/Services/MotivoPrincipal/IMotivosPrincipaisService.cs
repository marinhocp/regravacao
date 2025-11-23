using Regravacao.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Regravacao.Services.MotivosPrincipais
{
    public interface IMotivosPrincipaisService
    {
        Task<List<MotivosPrincipaisDto>> ObterTodosMotivosAsync();
    }
}