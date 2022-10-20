namespace PsicoOnline.Core.DTO;

public class SessaoUpdateDTO
{
    public int Id { get; set; }

    public int PacienteId { get; set; }

    public DateTime DataSessao { get; set; }

    public string Anotacao { get; set; }
}