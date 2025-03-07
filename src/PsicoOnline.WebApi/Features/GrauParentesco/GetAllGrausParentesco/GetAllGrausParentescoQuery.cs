using MediatR;

namespace PsicoOnline.WebApi.Features.GrauParentesco.GetAllGrausParentesco;

public record GetAllGrausParentescoQuery : IRequest<IReadOnlyList<Core.Entities.GrauParentesco>>;