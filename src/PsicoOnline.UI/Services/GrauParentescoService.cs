namespace PsicoOnline.UI.Services;

public class GrauParentescoService(HttpClient httpClient, NavigationManager navigationManager) : IGrauParentescoService
{
	public List<GrauParentescoModel> GrausParentesco { get; set; }

	public async Task AddGrauParentescoAsync(GrauParentescoModel grauParentesco)
	{
		_ = await httpClient.PostAsJsonAsync("GrauParentesco/Add", grauParentesco);
		await SetGrausParentesco();
	}

	public async Task DeleteGrauParentescoAsync(int id)
	{
		_ = await httpClient.DeleteAsync($"GrauParentesco/Delete/{id}");
		await SetGrausParentesco();
	}

	public async Task GetAllGrausParentescoAsync()
	{
		var grausParentesco = await httpClient.GetFromJsonAsync<List<GrauParentescoModel>>("GrauParentesco/GetAll");

		if (grausParentesco != null)
		{
			GrausParentesco = grausParentesco;
		}
	}

	public async Task<GrauParentescoModel> GetGrauParentescoByIdAsync(int id)
	{
		var grauParentesco = await httpClient.GetFromJsonAsync<GrauParentescoModel>($"GrauParentesco/GetById/{id}");

		if (grauParentesco != null)
		{
			return grauParentesco;
		}

		throw new Exception($"Não há grau de parentesco cadastrado com o id {id}.");
	}

	private async Task SetGrausParentesco()
	{
		await GetAllGrausParentescoAsync();
		navigationManager.NavigateTo("grausparentesco");
	}

	public async Task UpdateGrauParentescoAsync(GrauParentescoModel grauParentesco)
	{
		_ = await httpClient.PutAsJsonAsync("GrauParentesco/Update", grauParentesco);
		await SetGrausParentesco();
	}
}