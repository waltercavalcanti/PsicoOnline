using MediatR;

namespace PsicoOnline.WebApi.Features.GrauParentesco.GetGrauParentescoById;

public record GetGrauParentescoByIdQuery(int Id) : IRequest<Core.Entities.GrauParentesco>;