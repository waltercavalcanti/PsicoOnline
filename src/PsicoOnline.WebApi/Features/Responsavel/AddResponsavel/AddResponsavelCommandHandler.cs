using MediatR;
using PsicoOnline.Core.DTO;
using PsicoOnline.Core.Interfaces;

namespace PsicoOnline.WebApi.Features.Responsavel.AddResponsavel;

public class AddResponsavelCommandHandler(IResponsavelRepository responsavelRepository) : IRequestHandler<AddResponsavelCommand, Core.Entities.Responsavel>
{
	public async Task<Core.Entities.Responsavel> Handle(AddResponsavelCommand request, CancellationToken cancellationToken)
	{
		var responsavelDTO = new ResponsavelAddDTO
		{
			Nome = request.Nome,
			DataNascimento = request.DataNascimento,
			Telefone = request.Telefone,
			Genero = request.Genero,
			PacienteId = request.PacienteId,
			GrauParentescoId = request.GrauParentescoId
		};

		var responsavel = await responsavelRepository.AddResponsavelAsync(responsavelDTO);

		return responsavel;
	}
}