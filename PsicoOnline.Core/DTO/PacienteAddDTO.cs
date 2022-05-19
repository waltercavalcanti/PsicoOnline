namespace PsicoOnline.Core.DTO
{
    public class PacienteAddDTO : PacienteDTO
    {
        public string Nome { get; set; }

        public DateTime DataNascimento { get; set; }

        public string Telefone { get; set; }

        public char Genero { get; set; }
    }
}