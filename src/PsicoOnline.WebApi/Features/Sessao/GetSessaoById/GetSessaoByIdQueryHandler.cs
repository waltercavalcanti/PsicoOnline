using MediatR;
using PsicoOnline.Core.Interfaces;

namespace PsicoOnline.WebApi.Features.Sessao.GetSessaoById;

public class GetSessaoByIdQueryHandler(ISessaoRepository sessaoRepository) : IRequestHandler<GetSessaoByIdQuery, Core.Entities.Sessao>
{
	public async Task<Core.Entities.Sessao> Handle(GetSessaoByIdQuery request, CancellationToken cancellationToken)
	{
		var sessao = await sessaoRepository.GetSessaoByIdAsync(request.Id);

		return sessao;
	}
}