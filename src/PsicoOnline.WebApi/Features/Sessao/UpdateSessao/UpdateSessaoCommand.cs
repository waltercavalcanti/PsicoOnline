using MediatR;

namespace PsicoOnline.WebApi.Features.Sessao.UpdateSessao;

public record UpdateSessaoCommand(int Id, int PacienteId, DateTime DataSessao, string Anotacao) : IRequest<string>;