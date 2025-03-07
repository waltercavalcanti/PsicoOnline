using MediatR;
using PsicoOnline.Core.Interfaces;

namespace PsicoOnline.WebApi.Features.Sessao.DeleteSessao;

public class DeleteSessaoCommandHandler(ISessaoRepository sessaoRepository) : IRequestHandler<DeleteSessaoCommand, string>
{
	public async Task<string> Handle(DeleteSessaoCommand request, CancellationToken cancellationToken)
	{
		await sessaoRepository.DeleteSessaoAsync(request.Id);

		return "Sessão excluída com sucesso.";
	}
}