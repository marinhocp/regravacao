using Regravacao.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Regravacao.Repositories.MotivosPrincipais
{
    public interface IMotivosPrincipaisRepository
    {
        Task<List<MotivosPrincipaisDto>> ListarTodosAsync();
    }
}