using MediatR;
using PsicoOnline.Core.DTO;
using PsicoOnline.Core.Interfaces;

namespace PsicoOnline.WebApi.Features.GrauParentesco.UpdateGrauParentesco;

public class UpdateGrauParentescoCommandHandler(IGrauParentescoRepository grauParentescoRepository) : IRequestHandler<UpdateGrauParentescoCommand, string>
{
	public async Task<string> Handle(UpdateGrauParentescoCommand request, CancellationToken cancellationToken)
	{
		var grauParentescoDTO = new GrauParentescoUpdateDTO
		{
			Id = request.Id,
			Descricao = request.Descricao
		};

		await grauParentescoRepository.UpdateGrauParentescoAsync(grauParentescoDTO);

		return "Grau de parentesco atualizado com sucesso.";
	}
}