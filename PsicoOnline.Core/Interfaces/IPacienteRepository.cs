using PsicoOnline.Core.DTO;
using PsicoOnline.Core.Entities;

namespace PsicoOnline.Core.Interfaces
{
    public interface IPacienteRepository
    {
        Task<Paciente> GetPacienteByIdAsync(int id);

        Task<IReadOnlyList<Paciente>> GetAllPacientesAsync();

        Task<Paciente> AddPacienteAsync(PacienteDTO pacienteDTO);

        Task UpdatePacienteAsync(PacienteDTO pacienteDTO);

        Task DeletePacienteAsync(int id);

        Task DeleteAllPacientesAsync();

        bool PacienteExists(int id);
    }
}