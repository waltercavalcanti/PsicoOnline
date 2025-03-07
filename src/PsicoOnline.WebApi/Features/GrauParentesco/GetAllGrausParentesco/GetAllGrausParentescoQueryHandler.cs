using MediatR;
using PsicoOnline.Core.Interfaces;

namespace PsicoOnline.WebApi.Features.GrauParentesco.GetAllGrausParentesco;

public class GetAllGrausParentescoQueryHandler(IGrauParentescoRepository grauParentescoRepository) : IRequestHandler<GetAllGrausParentescoQuery, IReadOnlyList<Core.Entities.GrauParentesco>>
{
	public async Task<IReadOnlyList<Core.Entities.GrauParentesco>> Handle(GetAllGrausParentescoQuery request, CancellationToken cancellationToken)
	{
		return await grauParentescoRepository.GetAllGrausParentescoAsync();
	}
}
