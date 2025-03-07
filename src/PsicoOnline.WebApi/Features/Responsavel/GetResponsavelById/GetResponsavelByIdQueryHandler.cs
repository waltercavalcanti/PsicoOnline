using MediatR;
using PsicoOnline.Core.Interfaces;

namespace PsicoOnline.WebApi.Features.Responsavel.GetResponsavelById;

public class GetResponsavelByIdQueryHandler(IResponsavelRepository responsavelRepository) : IRequestHandler<GetResponsavelByIdQuery, Core.Entities.Responsavel>
{
	public async Task<Core.Entities.Responsavel> Handle(GetResponsavelByIdQuery request, CancellationToken cancellationToken)
	{
		var responsavel = await responsavelRepository.GetResponsavelByIdAsync(request.Id);

		return responsavel;
	}
}