using PsicoOnline.Core.DTO;
using PsicoOnline.Core.Entities;

namespace PsicoOnline.Core.Interfaces
{
    public interface IPacienteRepository
    {
        Paciente GetPacienteById(int id);

        IReadOnlyList<Paciente> GetAllPacientes();

        Paciente AddPaciente(PacienteDTO pacienteDTO);

        void UpdatePaciente(PacienteDTO pacienteDTO);

        void DeletePaciente(int id);

        void DeleteAllPacientes();

        bool PacienteExists(int id);
    }
}