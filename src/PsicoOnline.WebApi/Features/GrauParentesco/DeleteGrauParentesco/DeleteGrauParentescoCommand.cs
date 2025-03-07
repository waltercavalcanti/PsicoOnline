using MediatR;

namespace PsicoOnline.WebApi.Features.GrauParentesco.DeleteGrauParentesco;

public record DeleteGrauParentescoCommand(int Id) : IRequest<string>;