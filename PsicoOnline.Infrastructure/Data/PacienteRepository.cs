using PsicoOnline.Core.DTO;
using PsicoOnline.Core.Entities;
using PsicoOnline.Core.Interfaces;
using PsicoOnline.Infrastructure.Mapper;

namespace PsicoOnline.Infrastructure.Data
{
    public class PacienteRepository : EFRepository<Paciente, int>, IPacienteRepository
    {
        public PacienteRepository(EFContext db) : base(db) { }

        public async Task<Paciente> AddPaciente(PacienteDTO pacienteDTO)
        {
            if (pacienteDTO == null)
            {
                throw new ArgumentNullException(nameof(pacienteDTO));
            }

            var paciente = PacienteMapper.Convert(pacienteDTO);

            await Add(paciente);

            return paciente;
        }

        public async Task DeleteAllPacientes()
        {
            var pacientes = await GetAll();

            await DeleteAll((List<Paciente>)pacientes);
        }

        public async Task DeletePaciente(int id)
        {
            if (!PacienteExists(id))
            {
                throw new Exception($"Paciente Id {id} não encontrado.");
            }

            var paciente = await GetById(id);

            await Delete(paciente);
        }

        public async Task<IReadOnlyList<Paciente>> GetAllPacientes()
        {
            var pacientes = await GetAll();

            foreach (var p in pacientes)
            {
                p.Responsavel = _db.Responsavel.FirstOrDefault(r => r.PacienteId == p.Id);
            }

            return pacientes;
        }

        public async Task<Paciente> GetPacienteById(int id)
        {
            var paciente = await GetById(id);

            paciente.Responsavel = _db.Responsavel.FirstOrDefault(r => r.PacienteId == id);

            return paciente;
        }

        public bool PacienteExists(int id) => _db.Paciente.Any(p => p.Id == id);

        public async Task UpdatePaciente(PacienteDTO pacienteDTO)
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

            await Update(paciente);
        }
    }
}