namespace PsicoOnline.Core.Entities
{
    public class Responsavel : BaseEntity<int>
    {
        public string Nome { get; set; }

        public DateTime DataNascimento { get; set; }

        public string Telefone { get; set; }

        public char Genero { get; set; }

        public Paciente Paciente { get; set; }

        public GrauParentesco GrauParentesco { get; set; }
    }
}