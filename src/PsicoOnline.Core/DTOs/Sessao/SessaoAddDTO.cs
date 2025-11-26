namespace PsicoOnline.Core.DTOs.Sessao;

public class SessaoAddDTO
{
	public int PacienteId { get; set; }

	public DateTime DataSessao { get; set; }

	public string Anotacao { get; set; }
}