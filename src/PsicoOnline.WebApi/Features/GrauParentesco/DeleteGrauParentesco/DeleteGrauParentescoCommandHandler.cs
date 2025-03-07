using MediatR;
using PsicoOnline.Core.Interfaces;

namespace PsicoOnline.WebApi.Features.GrauParentesco.DeleteGrauParentesco;

public class DeleteGrauParentescoCommandHandler(IGrauParentescoRepository grauParentescoRepository) : IRequestHandler<DeleteGrauParentescoCommand, string>
{
	public async Task<string> Handle(DeleteGrauParentescoCommand request, CancellationToken cancellationToken)
	{
		await grauParentescoRepository.DeleteGrauParentescoAsync(request.Id);

		return "Grau de parentesco excluído com sucesso.";
	}
}