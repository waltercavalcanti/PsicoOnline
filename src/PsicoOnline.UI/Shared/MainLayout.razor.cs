namespace PsicoOnline.UI.Shared;

public partial class MainLayout
{
	bool gavetaAberta = true;
	private bool modoEscuro;
	private string iconeAtual = Icons.Material.Outlined.LightMode;

	void AlternarGaveta()
	{
		gavetaAberta = !gavetaAberta;
	}

	private Task AlternarModoEscuro()
	{
		modoEscuro = !modoEscuro;

		iconeAtual = modoEscuro ? Icons.Material.Outlined.DarkMode : Icons.Material.Outlined.LightMode;

		return Task.CompletedTask;
	}
}