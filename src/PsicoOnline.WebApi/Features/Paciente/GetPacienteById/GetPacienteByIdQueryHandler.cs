using MediatR;
using PsicoOnline.Core.Interfaces;

namespace PsicoOnline.WebApi.Features.Paciente.GetPacienteById;

public class GetPacienteByIdQueryHandler(IPacienteRepository pacienteRepository) : IRequestHandler<GetPacienteByIdQuery, Core.Entities.Paciente>
{
	public async Task<Core.Entities.Paciente> Handle(GetPacienteByIdQuery request, CancellationToken cancellationToken)
	{
		var paciente = await pacienteRepository.GetPacienteByIdAsync(request.Id);

		return paciente;
	}
}