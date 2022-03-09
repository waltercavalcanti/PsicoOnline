namespace PsicoOnline.Core.DTO
{
    public class SessaoDTO
    {
        public int Id { get; set; }

        public PacienteDTO Paciente { get; set; }

        public DateTime DataSessao { get; set; }

        public string Anotacao { get; set; }
    }
}