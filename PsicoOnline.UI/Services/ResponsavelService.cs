namespace PsicoOnline.UI.Services;

public class ResponsavelService : IResponsavelService
{
	private readonly HttpClient _httpClient;
	private readonly NavigationManager _navigationManager;

	public ResponsavelService(HttpClient httpClient, NavigationManager navigationManager)
	{
		_httpClient = httpClient;
		_navigationManager = navigationManager;
	}

	public List<ResponsavelModel> Responsaveis { get; set; }

	public async Task AddResponsavelAsync(ResponsavelModel responsavel)
	{
		_ = await _httpClient.PostAsJsonAsync("Responsavel/Add", responsavel);
		await SetResponsaveis();
	}

	public async Task DeleteResponsavelAsync(int id)
	{
		_ = await _httpClient.DeleteAsync($"Responsavel/Delete/{id}");
		await SetResponsaveis();
	}

	public async Task GetAllResponsaveisAsync()
	{
		var responsaveis = await _httpClient.GetFromJsonAsync<List<ResponsavelModel>>("Responsavel/GetAll");

		if (responsaveis != null)
		{
			Responsaveis = responsaveis;
		}
	}

	public async Task<ResponsavelModel> GetResponsavelByIdAsync(int id)
	{
		var responsavel = await _httpClient.GetFromJsonAsync<ResponsavelModel>($"Responsavel/GetById/{id}");

		if (responsavel != null)
		{
			return responsavel;
		}

		throw new Exception($"Não há responsável cadastrado com o id {id}.");
	}

	private async Task SetResponsaveis()
	{
		await GetAllResponsaveisAsync();
		_navigationManager.NavigateTo("responsaveis");
	}

	public async Task UpdateResponsavelAsync(ResponsavelModel responsavel)
	{
		_ = await _httpClient.PutAsJsonAsync("Responsavel/Update", responsavel);
		await SetResponsaveis();
	}
}