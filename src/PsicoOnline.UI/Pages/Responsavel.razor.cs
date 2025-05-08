namespace PsicoOnline.UI.Pages;

public partial class Responsavel
{
	[Parameter]
	public int? Id { get; set; }

	string titulo = string.Empty;

	ResponsavelModel responsavel = new() { Genero = 'M' };

	protected override async Task OnInitializedAsync() => titulo = Id == null ? "Adicionar Responsável" : "Editar Responsável";

	protected override async Task OnParametersSetAsync()
	{
		if (Id != null)
		{
			responsavel = await ResponsavelService.GetResponsavelByIdAsync((int)Id);
		}
	}

	async Task SubmeterAsync()
	{
		if (Id == null)
		{
			await ResponsavelService.AddResponsavelAsync(responsavel);
		}
		else
		{
			await ResponsavelService.UpdateResponsavelAsync(responsavel);
		}
	}

	async Task DeleteResponsavelAsync()
	{
		await ResponsavelService.DeleteResponsavelAsync(responsavel.Id);
	}
}