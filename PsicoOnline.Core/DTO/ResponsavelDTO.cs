namespace PsicoOnline.Core.DTO
{
    public class ResponsavelDTO
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public DateTime DataNascimento { get; set; }

        public string Telefone { get; set; }

        public char Genero { get; set; }

        public PacienteDTO Paciente { get; set; }

        public GrauParentescoDTO GrauParentesco { get; set; }
    }
}