namespace PsicoOnline.UI.Services;

public class ResponsavelService(HttpClient httpClient, NavigationManager navigationManager) : IResponsavelService
{
	public List<ResponsavelModel> Responsaveis { get; set; }

	public async Task AddResponsavelAsync(ResponsavelModel responsavel)
	{
		_ = await httpClient.PostAsJsonAsync("Responsavel/Add", responsavel);
		await SetResponsaveis();
	}

	public async Task DeleteResponsavelAsync(int id)
	{
		_ = await httpClient.DeleteAsync($"Responsavel/Delete/{id}");
		await SetResponsaveis();
	}

	public async Task GetAllResponsaveisAsync()
	{
		var responsaveis = await httpClient.GetFromJsonAsync<List<ResponsavelModel>>("Responsavel/GetAll");

		if (responsaveis != null)
		{
			Responsaveis = responsaveis;
		}
	}

	public async Task<ResponsavelModel> GetResponsavelByIdAsync(int id)
	{
		var responsavel = await httpClient.GetFromJsonAsync<ResponsavelModel>($"Responsavel/GetById/{id}");

		if (responsavel != null)
		{
			return responsavel;
		}

		throw new Exception($"Não há responsável cadastrado com o id {id}.");
	}

	private async Task SetResponsaveis()
	{
		await GetAllResponsaveisAsync();
		navigationManager.NavigateTo("responsaveis");
	}

	public async Task UpdateResponsavelAsync(ResponsavelModel responsavel)
	{
		_ = await httpClient.PutAsJsonAsync("Responsavel/Update", responsavel);
		await SetResponsaveis();
	}
}