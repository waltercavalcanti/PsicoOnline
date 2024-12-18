namespace PsicoOnline.UI.Pages;

public partial class GrausParentesco
{
	private string searchString = "";
	private readonly int[] pageSizes = [5, 10, 15, 20, 25];

	protected override async Task OnInitializedAsync()
	{
		await GrauParentescoService.GetAllGrausParentescoAsync();
	}

	void EditarGrauParentesco(int id)
	{
		NavigationManager.NavigateTo($"grauparentesco/{id}");
	}

	void AddGrauParentesco()
	{
		NavigationManager.NavigateTo("grauparentesco");
	}

	private bool Filtrar(GrauParentescoModel grauParentesco) => Filtrar(grauParentesco, searchString);

	private static bool Filtrar(GrauParentescoModel grauParentesco, string searchString)
	{
		if (string.IsNullOrWhiteSpace(searchString))
		{
			return true;
		}

		if (grauParentesco.Descricao.Contains(searchString, StringComparison.OrdinalIgnoreCase))
		{
			return true;
		}

		return false;
	}
}