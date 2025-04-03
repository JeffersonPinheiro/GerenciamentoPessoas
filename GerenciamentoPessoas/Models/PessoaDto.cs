namespace GerenciamentoPessoas.Models
{
    public class PessoaDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public char Sexo { get; set; }
        public double Peso { get; set; }
        public double? Altura { get; set; }
        public bool Idoso { get; set; }
    }
}
