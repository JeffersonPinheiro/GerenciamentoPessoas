using System.ComponentModel.DataAnnotations;

namespace GerenciamentoPessoas.Entities
{
    public class Pessoa
    {
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public int Idade { get; set; }
        [Required]
        public char Sexo { get; set; }
        [Required]
        public double Peso { get; set; }
        public double? Altura { get; set; }
        [Required]
        public bool Idoso { get; set; }
    }
}
