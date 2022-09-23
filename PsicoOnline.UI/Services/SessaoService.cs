namespace PsicoOnline.UI.Services;

public class SessaoService : ISessaoService
{
    private readonly HttpClient _httpClient;
    private readonly NavigationManager _navigationManager;

    public SessaoService(HttpClient httpClient, NavigationManager navigationManager)
    {
        _httpClient = httpClient;
        _navigationManager = navigationManager;
    }

    public List<SessaoModel> Sessoes { get; set; }

    public async Task AddSessaoAsync(SessaoModel sessao)
    {
        _ = await _httpClient.PostAsJsonAsync("Sessao/Add", sessao);
        await SetSessoes();
    }

    public async Task DeleteSessaoAsync(int id)
    {
        _ = await _httpClient.DeleteAsync($"Sessao/Delete/{id}");
        await SetSessoes();
    }

    public async Task GetAllSessoesAsync()
    {
        var sessoes = await _httpClient.GetFromJsonAsync<List<SessaoModel>>("Sessao/GetAll");

        if (sessoes != null)
        {
            Sessoes = sessoes;
        }
    }

    public async Task<SessaoModel> GetSessaoByIdAsync(int id)
    {
        var sessao = await _httpClient.GetFromJsonAsync<SessaoModel>($"Sessao/GetById/{id}");

        if (sessao != null)
        {
            return sessao;
        }

        throw new Exception($"Não há sessão cadastrada com o id {id}.");
    }

    private async Task SetSessoes()
    {
        await GetAllSessoesAsync();
        _navigationManager.NavigateTo("sessoes");
    }

    public async Task UpdateSessaoAsync(SessaoModel sessao)
    {
        _ = await _httpClient.PutAsJsonAsync("Sessao/Update", sessao);
        await SetSessoes();
    }
}