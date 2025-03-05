namespace PsicoOnline.Core.Entities;

public class Sessao : BaseEntity<int>
{
	public int PacienteId { get; set; }

	public Paciente Paciente { get; set; }

	public DateTime DataSessao { get; set; }

	public string Anotacao { get; set; }
}