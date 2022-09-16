using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace PsicoOnline.UI.Services;

public class GrauParentescoService : IGrauParentescoService
{
    private readonly HttpClient _httpClient;
    private readonly NavigationManager _navigationManager;

    public GrauParentescoService(HttpClient httpClient, NavigationManager navigationManager)
    {
        _httpClient = httpClient;
        _navigationManager = navigationManager;
    }

    public List<GrauParentescoModel> GrausParentesco { get; set; }

    public async Task AddGrauParentescoAsync(GrauParentescoModel grauParentesco)
    {
        _ = await _httpClient.PostAsJsonAsync("GrauParentesco/Add", grauParentesco);
        await SetGrausParentesco();
    }

    public async Task DeleteGrauParentescoAsync(int id)
    {
        _ = await _httpClient.DeleteAsync($"GrauParentesco/Delete/{id}");
        await SetGrausParentesco();
    }

    public async Task GetAllGrausParentescoAsync()
    {
        var grausParentesco = await _httpClient.GetFromJsonAsync<List<GrauParentescoModel>>("GrauParentesco/GetAll");

        if (grausParentesco != null)
        {
            GrausParentesco = grausParentesco;
        }
    }

    public async Task<GrauParentescoModel> GetGrauParentescoByIdAsync(int id)
    {
        var grauParentesco = await _httpClient.GetFromJsonAsync<GrauParentescoModel>($"GrauParentesco/GetById/{id}");

        if (grauParentesco != null)
        {
            return grauParentesco;
        }

        throw new Exception($"Não há grau de parentesco cadastrado com o id {id}.");
    }

    private async Task SetGrausParentesco()
    {
        await GetAllGrausParentescoAsync();
        _navigationManager.NavigateTo("grausparentesco");
    }

    public async Task UpdateGrauParentescoAsync(GrauParentescoModel grauParentesco)
    {
        _ = await _httpClient.PutAsJsonAsync("GrauParentesco/Update", grauParentesco);
        await SetGrausParentesco();
    }
}