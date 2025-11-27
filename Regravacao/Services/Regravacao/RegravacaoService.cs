using Regravacao.DTOs;
using Regravacao.Repositories.Regravacao;
using System.Threading.Tasks;

namespace Regravacao.Services.Regravacao
{
    public class RegravacaoService : IRegravacaoService
    {
        private readonly IRegravacaoRepository _repo;

        public RegravacaoService(IRegravacaoRepository repo)
        {
            _repo = repo;
        }

        public async Task<int> InserirAsync(RegravacaoInserirDto dto)
        {
            return await _repo.InserirRegravacaoAsync(dto);
        }
    }
}
