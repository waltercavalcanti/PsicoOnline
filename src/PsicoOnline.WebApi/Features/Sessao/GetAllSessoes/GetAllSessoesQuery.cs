using MediatR;

namespace PsicoOnline.WebApi.Features.Sessao.GetAllSessoes;

public record GetAllSessoesQuery : IRequest<IReadOnlyList<Core.Entities.Sessao>>;