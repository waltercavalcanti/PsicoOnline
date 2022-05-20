namespace PsicoOnline.Core.DTO
{
    public class SessaoAddDTO : SessaoDTO
    {
        public int PacienteId { get; set; }

        public DateTime DataSessao { get; set; }

        public string Anotacao { get; set; }
    }
}