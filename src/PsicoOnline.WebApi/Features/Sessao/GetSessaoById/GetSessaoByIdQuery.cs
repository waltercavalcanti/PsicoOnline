using MediatR;

namespace PsicoOnline.WebApi.Features.Sessao.GetSessaoById;

public record GetSessaoByIdQuery(int Id) : IRequest<Core.Entities.Sessao>;