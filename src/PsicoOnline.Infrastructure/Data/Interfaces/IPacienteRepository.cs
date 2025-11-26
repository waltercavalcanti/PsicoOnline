using PsicoOnline.Core.DTOs.Paciente;
using PsicoOnline.Core.Entities;
using System.Linq.Expressions;

namespace PsicoOnline.Infrastructure.Data.Interfaces;

public interface IPacienteRepository
{
	Task<Paciente> GetPacienteByIdAsync(int id);

	Task<IReadOnlyList<Paciente>> GetAllPacientesAsync();

	Task<IReadOnlyList<Paciente>> GetPacientesWhereAsync(Expression<Func<Paciente, bool>> where);

	Task<Paciente> AddPacienteAsync(PacienteAddDTO pacienteDTO);

	Task UpdatePacienteAsync(PacienteUpdateDTO pacienteDTO);

	Task DeletePacienteAsync(int id);

	bool PacienteExists(int id);
}