using MediatR;
using PsicoOnline.Core.DTO;
using PsicoOnline.Core.Interfaces;

namespace PsicoOnline.WebApi.Features.Sessao.GetSessoesByPacienteIdData;

public class GetSessoesByPacienteIdDataQueryHandler(ISessaoRepository sessaoRepository) : IRequestHandler<GetSessoesByPacienteIdDataQuery, IReadOnlyList<Core.Entities.Sessao>>
{
	public async Task<IReadOnlyList<Core.Entities.Sessao>> Handle(GetSessoesByPacienteIdDataQuery request, CancellationToken cancellationToken)
	{
		var sessaoDTO = new SessaoFilterDTO
		{
			PacienteId = request.PacienteId,
			DataSessao = request.DataSessao
		};

		var sessoes = await sessaoRepository.GetSessoesByPacienteIdDataAsync(sessaoDTO);

		return sessoes;
	}
}