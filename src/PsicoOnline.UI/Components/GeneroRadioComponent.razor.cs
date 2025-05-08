namespace PsicoOnline.UI.Components;

public partial class GeneroRadioComponent
{
	static readonly List<GeneroModel> generos = new()
	{
		new GeneroModel{ Id = 'M', Descricao = "Masculino" },
		new GeneroModel{ Id = 'F', Descricao = "Feminino" }
	};
}