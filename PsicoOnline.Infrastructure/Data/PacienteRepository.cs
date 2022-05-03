using PsicoOnline.Core.DTO;
using PsicoOnline.Core.Entities;
using PsicoOnline.Core.Exceptions;
using PsicoOnline.Core.Interfaces;
using PsicoOnline.Infrastructure.Mapper;

namespace PsicoOnline.Infrastructure.Data
{
    public class PacienteRepository : EFRepository<Paciente, int>, IPacienteRepository
    {
        public PacienteRepository(EFContext db) : base(db) { }

        public async Task<Paciente> AddPacienteAsync(PacienteDTO pacienteDTO)
        {
            if (pacienteDTO == null)
            {
                throw new ArgumentNullException(nameof(pacienteDTO));
            }

            var paciente = PacienteMapper.Convert(pacienteDTO);

            await AddAsync(paciente);

            return paciente;
        }

        public async Task DeleteAllPacientesAsync()
        {
            var pacientes = await GetAllAsync();

            await DeleteAllAsync((List<Paciente>)pacientes);
        }

        public async Task DeletePacienteAsync(int id)
        {
            if (!PacienteExists(id))
            {
                throw new PacienteNaoExisteException(id);
            }

            var paciente = await GetByIdAsync(id);

            await DeleteAsync(paciente);
        }

        public async Task<IReadOnlyList<Paciente>> GetAllPacientesAsync()
        {
            var pacientes = await GetAllAsync();

            foreach (var p in pacientes)
            {
                p.Responsavel = _db.Responsavel.FirstOrDefault(r => r.PacienteId == p.Id);
            }

            return pacientes;
        }

        public async Task<Paciente> GetPacienteByIdAsync(int id)
        {
            var paciente = await GetByIdAsync(id);

            paciente.Responsavel = _db.Responsavel.FirstOrDefault(r => r.PacienteId == id);

            return paciente;
        }

        public bool PacienteExists(int id) => _db.Paciente.Any(p => p.Id == id);

        public async Task UpdatePacienteAsync(PacienteDTO pacienteDTO)
        {
            if (pacienteDTO == null)
            {
                throw new ArgumentNullException(nameof(pacienteDTO));
            }

            if (!PacienteExists(pacienteDTO.Id))
            {
                throw new PacienteNaoExisteException(pacienteDTO.Id);
            }

            var paciente = PacienteMapper.Convert(pacienteDTO);

            await UpdateAsync(paciente);
        }
    }
}