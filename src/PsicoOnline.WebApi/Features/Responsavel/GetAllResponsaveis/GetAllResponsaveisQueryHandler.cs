using MediatR;
using PsicoOnline.Core.Interfaces;

namespace PsicoOnline.WebApi.Features.Responsavel.GetAllResponsaveis;

public class GetAllResponsaveisQueryHandler(IResponsavelRepository responsavelRepository) : IRequestHandler<GetAllResponsaveisQuery, IReadOnlyList<Core.Entities.Responsavel>>
{
	public async Task<IReadOnlyList<Core.Entities.Responsavel>> Handle(GetAllResponsaveisQuery request, CancellationToken cancellationToken)
	{
		return await responsavelRepository.GetAllResponsaveisAsync();
	}
}