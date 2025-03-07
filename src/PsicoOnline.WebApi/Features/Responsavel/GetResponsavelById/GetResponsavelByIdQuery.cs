using MediatR;

namespace PsicoOnline.WebApi.Features.Responsavel.GetResponsavelById;

public record GetResponsavelByIdQuery(int Id) : IRequest<Core.Entities.Responsavel>;