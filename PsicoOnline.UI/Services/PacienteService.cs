namespace PsicoOnline.UI.Services;

public class PacienteService : IPacienteService
{
	private readonly HttpClient _httpClient;
	private readonly NavigationManager _navigationManager;

	public PacienteService(HttpClient httpClient, NavigationManager navigationManager)
	{
		_httpClient = httpClient;
		_navigationManager = navigationManager;
	}

	public List<PacienteModel> Pacientes { get; set; }

	public async Task AddPacienteAsync(PacienteModel paciente)
	{
		_ = await _httpClient.PostAsJsonAsync("Paciente/Add", paciente);
		await SetPacientes();
	}

	public async Task DeletePacienteAsync(int id)
	{
		_ = await _httpClient.DeleteAsync($"Paciente/Delete/{id}");
		await SetPacientes();
	}

	public async Task GetAllPacientesAsync()
	{
		var pacientes = await _httpClient.GetFromJsonAsync<List<PacienteModel>>("Paciente/GetAll");

		if (pacientes != null)
		{
			Pacientes = pacientes;
		}
	}

	public async Task<PacienteModel> GetPacienteByIdAsync(int id)
	{
		var paciente = await _httpClient.GetFromJsonAsync<PacienteModel>($"Paciente/GetById/{id}");

		if (paciente != null)
		{
			return paciente;
		}

		throw new Exception($"Não há paciente cadastrado com o id {id}.");
	}

	private async Task SetPacientes()
	{
		await GetAllPacientesAsync();
		_navigationManager.NavigateTo("pacientes");
	}

	public async Task UpdatePacienteAsync(PacienteModel paciente)
	{
		_ = await _httpClient.PutAsJsonAsync("Paciente/Update", paciente);
		await SetPacientes();
	}
}