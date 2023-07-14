namespace PsicoOnline.UI.Components;

public partial class GeneroComponent
{
	[Parameter]
	public PacienteModel Paciente { get; set; }

	[Parameter]
	public ResponsavelModel Responsavel { get; set; }

	static readonly List<GeneroModel> generos = new()
	{
		new GeneroModel{ Id = 'M', Descricao = "Masculino" },
		new GeneroModel{ Id = 'F', Descricao = "Feminino" }
	};
}