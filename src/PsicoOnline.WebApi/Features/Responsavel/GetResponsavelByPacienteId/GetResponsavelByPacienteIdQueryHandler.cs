using MediatR;
using PsicoOnline.Core.Interfaces;
using System.Linq.Expressions;

namespace PsicoOnline.WebApi.Features.Responsavel.GetResponsavelByPacienteId;

public class GetResponsavelByPacienteIdQueryHandler(IResponsavelRepository responsavelRepository) : IRequestHandler<GetResponsavelByPacienteIdQuery, Core.Entities.Responsavel>
{
	public async Task<Core.Entities.Responsavel> Handle(GetResponsavelByPacienteIdQuery request, CancellationToken cancellationToken)
	{
		Expression<Func<Core.Entities.Responsavel, bool>> where = responsavel => responsavel.PacienteId == request.Id;

		var responsavel = await responsavelRepository.GetResponsaveisWhereAsync(where);

		return responsavel.FirstOrDefault();
	}
}