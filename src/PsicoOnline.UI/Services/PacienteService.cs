namespace PsicoOnline.UI.Services;

public class PacienteService(HttpClient httpClient, NavigationManager navigationManager) : IPacienteService
{
	public List<PacienteModel> Pacientes { get; set; }

	public async Task AddPacienteAsync(PacienteModel paciente)
	{
		_ = await httpClient.PostAsJsonAsync("Paciente/Add", paciente);
		await SetPacientes();
	}

	public async Task DeletePacienteAsync(int id)
	{
		_ = await httpClient.DeleteAsync($"Paciente/Delete/{id}");
		await SetPacientes();
	}

	public async Task GetAllPacientesAsync()
	{
		var pacientes = await httpClient.GetFromJsonAsync<List<PacienteModel>>("Paciente/GetAll");

		if (pacientes != null)
		{
			foreach (var paciente in pacientes)
			{
				var responsavel = await httpClient.GetFromJsonAsync<ResponsavelModel>($"Responsavel/GetByPacienteId/{paciente.Id}");

				if (responsavel != null)
				{
					paciente.ResponsavelId = responsavel.Id;
					paciente.Responsavel = responsavel;
				}
			}

			Pacientes = pacientes;
		}
	}

	public async Task<PacienteModel> GetPacienteByIdAsync(int id)
	{
		var paciente = await httpClient.GetFromJsonAsync<PacienteModel>($"Paciente/GetById/{id}");

		if (paciente != null)
		{
			return paciente;
		}

		throw new Exception($"Não há paciente cadastrado com o id {id}.");
	}

	private async Task SetPacientes()
	{
		await GetAllPacientesAsync();
		navigationManager.NavigateTo("pacientes");
	}

	public async Task UpdatePacienteAsync(PacienteModel paciente)
	{
		_ = await httpClient.PutAsJsonAsync("Paciente/Update", paciente);
		await SetPacientes();
	}
}