namespace PsicoOnline.Core.DTO
{
    public class SessaoFilterDTO : SessaoDTO
    {
        public int? PacienteId { get; set; }

        public DateTime? DataSessao { get; set; }
    }
}