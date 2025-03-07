using MediatR;
using PsicoOnline.Core.DTO;
using PsicoOnline.Core.Interfaces;

namespace PsicoOnline.WebApi.Features.Paciente.AddPaciente;

public class AddPacienteCommandHandler(IPacienteRepository pacienteRepository) : IRequestHandler<AddPacienteCommand, Core.Entities.Paciente>
{
	public async Task<Core.Entities.Paciente> Handle(AddPacienteCommand request, CancellationToken cancellationToken)
	{
		var pacienteDTO = new PacienteAddDTO
		{
			Nome = request.Nome,
			DataNascimento = request.DataNascimento,
			Telefone = request.Telefone,
			Genero = request.Genero
		};

		var paciente = await pacienteRepository.AddPacienteAsync(pacienteDTO);

		return paciente;
	}
}