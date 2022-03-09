using PsicoOnline.Core.DTO;
using PsicoOnline.Core.Entities;
using PsicoOnline.Core.Interfaces;
using PsicoOnline.Infrastructure.Mapper;

namespace PsicoOnline.Infrastructure.Data
{
    public class PacienteRepository : EFRepository<Paciente, int>, IPacienteRepository
    {
        public PacienteRepository(EFContext db) : base(db) { }

        public Paciente AddPaciente(PacienteDTO pacienteDTO)
        {
            if (pacienteDTO == null)
            {
                throw new ArgumentNullException(nameof(pacienteDTO));
            }

            var paciente = PacienteMapper.Convert(pacienteDTO);

            Add(paciente);

            return paciente;
        }

        public void DeleteAllPacientes()
        {
            DeleteAll((List<Paciente>)GetAll());
        }

        public void DeletePaciente(int id)
        {
            if (!PacienteExists(id))
            {
                throw new Exception($"Paciente Id {id} não encontrado.");
            }

            var paciente = GetById(id);

            Delete(paciente);
        }

        public IReadOnlyList<Paciente> GetAllPacientes()
        {
            return GetAll();
        }

        public Paciente GetPacienteById(int id)
        {
            return GetById(id);
        }

        public bool PacienteExists(int id)
        {
            return db.Paciente.Any(paciente => paciente.Id == id);
        }

        public void UpdatePaciente(PacienteDTO pacienteDTO)
        {
            if (pacienteDTO == null)
            {
                throw new ArgumentNullException(nameof(pacienteDTO));
            }

            if (!PacienteExists(pacienteDTO.Id))
            {
                throw new Exception($"Paciente Id {pacienteDTO.Id} não encontrado.");
            }

            var paciente = PacienteMapper.Convert(pacienteDTO);

            Update(paciente);
        }
    }
}