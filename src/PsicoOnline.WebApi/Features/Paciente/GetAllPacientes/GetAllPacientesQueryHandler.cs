using MediatR;
using PsicoOnline.Core.Interfaces;

namespace PsicoOnline.WebApi.Features.Paciente.GetAllPacientes;

public class GetAllPacientesQueryHandler(IPacienteRepository pacienteRepository) : IRequestHandler<GetAllPacientesQuery, IReadOnlyList<Core.Entities.Paciente>>
{
	public async Task<IReadOnlyList<Core.Entities.Paciente>> Handle(GetAllPacientesQuery request, CancellationToken cancellationToken)
	{
		return await pacienteRepository.GetAllPacientesAsync();
	}
}