namespace PsicoOnline.UI.Pages;

public partial class Pacientes
{
	private string searchString = "";
	private readonly int[] pageSizes = [5, 10, 15, 20, 25];

	protected override async Task OnInitializedAsync()
	{
		await PacienteService.GetAllPacientesAsync();
	}

	void EditarPaciente(int id)
	{
		NavigationManager.NavigateTo($"paciente/{id}");
	}

	void AddPaciente()
	{
		NavigationManager.NavigateTo("paciente");
	}

	private bool Filtrar(PacienteModel paciente) => Filtrar(paciente, searchString);

	private static bool Filtrar(PacienteModel paciente, string searchString)
	{
		if (string.IsNullOrWhiteSpace(searchString))
		{
			return true;
		}

		if (paciente.Nome.Contains(searchString, StringComparison.OrdinalIgnoreCase))
		{
			return true;
		}

		return false;
	}
}