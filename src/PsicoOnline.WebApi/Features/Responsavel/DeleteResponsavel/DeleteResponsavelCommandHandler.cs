using MediatR;
using PsicoOnline.Core.Interfaces;

namespace PsicoOnline.WebApi.Features.Responsavel.DeleteResponsavel;

public class DeleteResponsavelCommandHandler(IResponsavelRepository responsavelRepository) : IRequestHandler<DeleteResponsavelCommand, string>
{
	public async Task<string> Handle(DeleteResponsavelCommand request, CancellationToken cancellationToken)
	{
		await responsavelRepository.DeleteResponsavelAsync(request.Id);

		return "Responsável excluído com sucesso.";
	}
}