namespace PsicoOnline.UI.Pages;

public partial class Responsaveis
{
	private string searchString = "";
	private readonly int[] pageSizes = new int[] { 5, 10, 15, 20, 25 };

	protected override async Task OnInitializedAsync()
	{
		await ResponsavelService.GetAllResponsaveisAsync();
	}

	void EditarResponsavel(int id)
	{
		NavigationManager.NavigateTo($"responsavel/{id}");
	}

	void EditarPaciente(int id)
	{
		NavigationManager.NavigateTo($"paciente/{id}");
	}

	void AddResponsavel()
	{
		NavigationManager.NavigateTo("responsavel");
	}

	private bool Filtrar(ResponsavelModel responsavel) => Filtrar(responsavel, searchString);

	private static bool Filtrar(ResponsavelModel responsavel, string searchString)
	{
		if (string.IsNullOrWhiteSpace(searchString))
		{
			return true;
		}

		if (responsavel.Nome.Contains(searchString, StringComparison.OrdinalIgnoreCase))
		{
			return true;
		}

		return false;
	}
}