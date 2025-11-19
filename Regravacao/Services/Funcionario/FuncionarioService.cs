using Regravacao.DTOs;
using Regravacao.Repositories.Funcionario;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Regravacao.Services.Funcionario.Impl
{
    public class FuncionarioService : IFuncionarioService
    {
        private readonly IFuncionarioRepository _repository;
        private const int ID_CARGO_FINALIZADOR = 4; // Regra de Negócio

        public FuncionarioService(IFuncionarioRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<FuncionariosDto>> ListarFinalizadoresAsync()
        {
            return await _repository.ListarPorCargoAsync(ID_CARGO_FINALIZADOR);
        }
    }
}