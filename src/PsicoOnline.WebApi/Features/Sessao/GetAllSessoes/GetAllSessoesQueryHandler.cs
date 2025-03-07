using MediatR;
using PsicoOnline.Core.Interfaces;

namespace PsicoOnline.WebApi.Features.Sessao.GetAllSessoes;

public class GetAllSessoesQueryHandler(ISessaoRepository sessaoRepository) : IRequestHandler<GetAllSessoesQuery, IReadOnlyList<Core.Entities.Sessao>>
{
	public async Task<IReadOnlyList<Core.Entities.Sessao>> Handle(GetAllSessoesQuery request, CancellationToken cancellationToken)
	{
		return await sessaoRepository.GetAllSessoesAsync();
	}
}