using GerenciamentoPessoas.Entities;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoPessoas.Data
{
    public class PessoaDbContext(DbContextOptions<PessoaDbContext> options) : DbContext(options)
    {
        public DbSet<Pessoa> Pessoas { get; set; }
    }
}
