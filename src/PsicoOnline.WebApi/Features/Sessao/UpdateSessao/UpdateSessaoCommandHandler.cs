using MediatR;
using PsicoOnline.Core.DTO;
using PsicoOnline.Core.Interfaces;

namespace PsicoOnline.WebApi.Features.Sessao.UpdateSessao;

public class UpdateSessaoCommandHandler(ISessaoRepository sessaoRepository) : IRequestHandler<UpdateSessaoCommand, string>
{
	public async Task<string> Handle(UpdateSessaoCommand request, CancellationToken cancellationToken)
	{
		var sessaoDTO = new SessaoUpdateDTO
		{
			Id = request.Id,
			PacienteId = request.PacienteId,
			DataSessao = request.DataSessao,
			Anotacao = request.Anotacao
		};

		await sessaoRepository.UpdateSessaoAsync(sessaoDTO);

		return "Sessão atualizada com sucesso.";
	}
}