using MediatR;
using PsicoOnline.Core.Interfaces;

namespace PsicoOnline.WebApi.Features.GrauParentesco.GetGrauParentescoById;

public class GetGrauParentescoByIdQueryHandler(IGrauParentescoRepository grauParentescoRepository) : IRequestHandler<GetGrauParentescoByIdQuery, Core.Entities.GrauParentesco>
{
	public async Task<Core.Entities.GrauParentesco> Handle(GetGrauParentescoByIdQuery request, CancellationToken cancellationToken)
	{
		var grauParentesco = await grauParentescoRepository.GetGrauParentescoByIdAsync(request.Id);

		return grauParentesco;
	}
}