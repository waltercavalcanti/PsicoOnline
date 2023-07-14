namespace PsicoOnline.UI.Pages;

public partial class GrauParentesco
{
	[Parameter]
	public int? Id { get; set; }

	string titulo = string.Empty;

	GrauParentescoModel grauParentesco = new();

	protected override async Task OnInitializedAsync() => titulo = Id == null ? "Adicionar Grau de Parentesco" : "Editar Grau de Parentesco";

	protected override async Task OnParametersSetAsync()
	{
		if (Id != null)
		{
			grauParentesco = await GrauParentescoService.GetGrauParentescoByIdAsync((int)Id);
		}
	}

	async Task SubmeterAsync()
	{
		if (Id == null)
		{
			await GrauParentescoService.AddGrauParentescoAsync(grauParentesco);
		}
		else
		{
			await GrauParentescoService.UpdateGrauParentescoAsync(grauParentesco);
		}
	}

	async Task DeleteGrauParentescoAsync()
	{
		await GrauParentescoService.DeleteGrauParentescoAsync(grauParentesco.Id);
	}
}