using MediatR;
using PsicoOnline.Core.DTO;
using PsicoOnline.Core.Interfaces;

namespace PsicoOnline.WebApi.Features.GrauParentesco.AddGrauParentesco;

public class AddGrauParentescoCommandHandler(IGrauParentescoRepository grauParentescoRepository) : IRequestHandler<AddGrauParentescoCommand, Core.Entities.GrauParentesco>
{
	public async Task<Core.Entities.GrauParentesco> Handle(AddGrauParentescoCommand request, CancellationToken cancellationToken)
	{
		var grauParentescoDTO = new GrauParentescoAddDTO
		{
			Descricao = request.Descricao
		};

		var grauParentesco = await grauParentescoRepository.AddGrauParentescoAsync(grauParentescoDTO);

		return grauParentesco;
	}
}