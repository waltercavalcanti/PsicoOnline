namespace PsicoOnline.UI.Services;

public interface IPacienteService
{
    List<PacienteModel> Pacientes { get; set; }

    Task AddPacienteAsync(PacienteModel paciente);

    Task DeletePacienteAsync(int id);

    Task GetAllPacientesAsync();

    Task<PacienteModel> GetPacienteByIdAsync(int id);

    Task UpdatePacienteAsync(PacienteModel grauParentesco);
}