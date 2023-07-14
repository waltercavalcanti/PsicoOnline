namespace PsicoOnline.UI.Components;

public partial class GeneroComponent
{
	[Parameter]
	public PacienteModel Paciente { get; set; }

	[Parameter]
	public ResponsavelModel Responsavel { get; set; }
}