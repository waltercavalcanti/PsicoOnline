namespace PsicoOnline.Core.DTO
{
    public class PacienteUpdateDTO : PacienteDTO
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public DateTime DataNascimento { get; set; }

        public string Telefone { get; set; }

        public char Genero { get; set; }
    }
}