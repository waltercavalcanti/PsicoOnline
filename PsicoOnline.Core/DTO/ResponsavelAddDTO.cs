namespace PsicoOnline.Core.DTO
{
    public class ResponsavelAddDTO : ResponsavelDTO
    {
        public string Nome { get; set; }

        public DateTime DataNascimento { get; set; }

        public string Telefone { get; set; }

        public char Genero { get; set; }

        public int PacienteId { get; set; }

        public int GrauParentescoId { get; set; }
    }
}