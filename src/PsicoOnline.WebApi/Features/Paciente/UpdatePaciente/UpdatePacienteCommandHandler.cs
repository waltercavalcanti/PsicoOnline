using MediatR;
using PsicoOnline.Core.DTO;
using PsicoOnline.Core.Interfaces;

namespace PsicoOnline.WebApi.Features.Paciente.UpdatePaciente;

public class UpdatePacienteCommandHandler(IPacienteRepository pacienteRepository) : IRequestHandler<UpdatePacienteCommand, string>
{
	public async Task<string> Handle(UpdatePacienteCommand request, CancellationToken cancellationToken)
	{
		var pacienteDTO = new PacienteUpdateDTO
		{
			Id = request.Id,
			Nome = request.Nome,
			DataNascimento = request.DataNascimento,
			Telefone = request.Telefone,
			Genero = request.Genero
		};

		await pacienteRepository.UpdatePacienteAsync(pacienteDTO);

		return "Paciente atualizado com sucesso.";
	}
}