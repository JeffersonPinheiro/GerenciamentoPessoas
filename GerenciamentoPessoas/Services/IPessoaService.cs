using GerenciamentoPessoas.Entities;
using GerenciamentoPessoas.Models;

namespace GerenciamentoPessoas.Services
{
    public interface IPessoaService
    {
        Task<List<PessoaDto>> ListarPessoasAsync(bool? apenasIdosos = null);
        Task<PessoaDto?> BuscarPessoaPorIdAsync(int id);
        Task<PessoaDto> AdicionarPessoaAsync(PessoaDto novaPessoa);
        Task<bool> AtualizarPessoaAsync(int id, PessoaDto pessoaDto);
        Task<bool> DeletarPessoaAsync(int id);
    }
}
