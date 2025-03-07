using MediatR;

namespace PsicoOnline.WebApi.Features.Sessao.DeleteSessao;

public record DeleteSessaoCommand(int Id) : IRequest<string>;