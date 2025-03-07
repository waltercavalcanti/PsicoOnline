using MediatR;
using PsicoOnline.Core.Interfaces;

namespace PsicoOnline.WebApi.Features.Paciente.DeletePaciente;

public class DeletePacienteCommandHandler(IPacienteRepository pacienteRepository) : IRequestHandler<DeletePacienteCommand, string>
{
	public async Task<string> Handle(DeletePacienteCommand request, CancellationToken cancellationToken)
	{
		await pacienteRepository.DeletePacienteAsync(request.Id);

		return "Paciente excluído com sucesso.";
	}
}