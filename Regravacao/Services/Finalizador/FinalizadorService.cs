using Regravacao.DTOs;
using Regravacao.Repositories.Finalizador;
using Regravacao.Repositories.Funcionario;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Regravacao.Services.Finalizador
{
    public class FinalizadorService : IFinalizadorService
    {
        private readonly IFinalizadorRepository _repository;
        
        private static readonly List<int> IDS_CARGOS_FINALIZADOR = new List<int> { 2, 3, 4 };

        public FinalizadorService(IFinalizadorRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<FuncionariosDto>> ListarFinalizadoresAsync()
        {
            return await _repository.ListarPorCargoAsync(IDS_CARGOS_FINALIZADOR);
        }
    }
}