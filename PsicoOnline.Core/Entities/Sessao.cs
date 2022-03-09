namespace PsicoOnline.Core.Entities
{
    public class Sessao : BaseEntity<int>
    {
        public Paciente Paciente { get; set; }

        public DateTime DataSessao { get; set; }

        public string Anotacao { get; set; }
    }
}