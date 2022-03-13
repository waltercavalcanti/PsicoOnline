using PsicoOnline.Core.DTO;
using PsicoOnline.Core.Entities;

namespace PsicoOnline.Core.Interfaces
{
    public interface IPacienteRepository
    {
        Task<Paciente> GetPacienteById(int id);

        Task<IReadOnlyList<Paciente>> GetAllPacientes();

        Task<Paciente> AddPaciente(PacienteDTO pacienteDTO);

        Task UpdatePaciente(PacienteDTO pacienteDTO);

        Task DeletePaciente(int id);

        Task DeleteAllPacientes();

        bool PacienteExists(int id);
    }
}