using MediatR;
using PsicoOnline.Core.DTO;
using PsicoOnline.Core.Interfaces;

namespace PsicoOnline.WebApi.Features.Responsavel.UpdateResponsavel;

public class UpdateResponsavelCommandHandler(IResponsavelRepository responsavelRepository) : IRequestHandler<UpdateResponsavelCommand, string>
{
	public async Task<string> Handle(UpdateResponsavelCommand request, CancellationToken cancellationToken)
	{
		var responsavelDTO = new ResponsavelUpdateDTO
		{
			Id = request.Id,
			Nome = request.Nome,
			DataNascimento = request.DataNascimento,
			Telefone = request.Telefone,
			Genero = request.Genero,
			PacienteId = request.PacienteId,
			GrauParentescoId = request.GrauParentescoId
		};

		await responsavelRepository.UpdateResponsavelAsync(responsavelDTO);

		return "Responsável atualizado com sucesso.";
	}
}