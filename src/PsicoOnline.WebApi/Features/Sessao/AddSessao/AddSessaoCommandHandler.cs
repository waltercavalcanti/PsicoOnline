using MediatR;
using PsicoOnline.Core.DTO;
using PsicoOnline.Core.Interfaces;

namespace PsicoOnline.WebApi.Features.Sessao.AddSessao;

public class AddSessaoCommandHandler(ISessaoRepository sessaoRepository) : IRequestHandler<AddSessaoCommand, Core.Entities.Sessao>
{
	public async Task<Core.Entities.Sessao> Handle(AddSessaoCommand request, CancellationToken cancellationToken)
	{
		var sessaoDTO = new SessaoAddDTO
		{
			PacienteId = request.PacienteId,
			DataSessao = request.DataSessao,
			Anotacao = request.Anotacao
		};

		var sessao = await sessaoRepository.AddSessaoAsync(sessaoDTO);

		return sessao;
	}
}