using GerenciamentoPessoas.Data;
using GerenciamentoPessoas.Entities;
using GerenciamentoPessoas.Models;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoPessoas.Services
{
    public class PessoaService : IPessoaService
    {
        private readonly PessoaDbContext _context;

        public PessoaService(PessoaDbContext context)
        {
            _context = context;
        }

        public async Task<List<PessoaDto>> ListarPessoasAsync(bool? apenasIdosos = null)
        {
            IQueryable<Pessoa> query = _context.Pessoas;
            
            if (apenasIdosos.HasValue)
            {
                query = query.Where(p => p.Idoso == apenasIdosos.Value);
            }

            var pessoas = await query.ToListAsync();
            var pessoasDto = new List<PessoaDto>();

            foreach (var pessoa in pessoas)
            {
                var pessoaDto = ConverterParaDto(pessoa);
                pessoasDto.Add(pessoaDto);
            }

            return pessoasDto;
        }

        public async Task<PessoaDto?> BuscarPessoaPorIdAsync(int id)
        {
            var pessoa = await _context.Pessoas.FindAsync(id);
            if (pessoa == null)
            {
                return null;
            }

            return ConverterParaDto(pessoa);
        }

        public async Task<PessoaDto> AdicionarPessoaAsync(PessoaDto novaPessoaDto)
        {
            var pessoa = ConverterParaEntidade(novaPessoaDto);

            VerificarEAtualizarStatusIdoso(pessoa);

            _context.Pessoas.Add(pessoa);
            await _context.SaveChangesAsync();

            novaPessoaDto.Id = pessoa.Id;
            novaPessoaDto.Idoso = pessoa.Idoso;

            return novaPessoaDto;
        }

        public async Task<bool> AtualizarPessoaAsync(int id, PessoaDto pessoaDto)
        {
            var pessoa = await _context.Pessoas.FindAsync(id);
            if (pessoa is null)
            {
                return false;
            }
            
            pessoa.Nome = pessoaDto.Nome;
            pessoa.Altura = pessoaDto.Altura;
            pessoa.Sexo = pessoaDto.Sexo;
            pessoa.Idade = pessoaDto.Idade;
            pessoa.Peso = pessoaDto.Peso;
            
            VerificarEAtualizarStatusIdoso(pessoa);

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeletarPessoaAsync(int id)
        {
            var pessoa = await _context.Pessoas.FindAsync(id);
            if (pessoa is null)
            {
                return false;
            }

            _context.Pessoas.Remove(pessoa);
            await _context.SaveChangesAsync();
            return true;
        }

        
        private void VerificarEAtualizarStatusIdoso(Pessoa pessoa)
        {
            pessoa.Idoso = pessoa.Idade >= 60;
        }

        
        private PessoaDto ConverterParaDto(Pessoa pessoa)
        {
            return new PessoaDto
            {
                Id = pessoa.Id,
                Nome = pessoa.Nome,
                Idade = pessoa.Idade,
                Sexo = pessoa.Sexo,
                Peso = pessoa.Peso,
                Altura = pessoa.Altura,
                Idoso = pessoa.Idade >= 60
            };
        }

        private Pessoa ConverterParaEntidade(PessoaDto dto)
        {
            return new Pessoa
            {
                Id = dto.Id, 
                Nome = dto.Nome,
                Idade = dto.Idade,
                Sexo = dto.Sexo,
                Peso = dto.Peso,
                Altura = dto.Altura,
                Idoso = dto.Idade >= 60 
            };
        }
    }
}