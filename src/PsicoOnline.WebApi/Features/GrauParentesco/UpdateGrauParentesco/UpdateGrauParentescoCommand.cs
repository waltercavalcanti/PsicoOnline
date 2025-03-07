using MediatR;

namespace PsicoOnline.WebApi.Features.GrauParentesco.UpdateGrauParentesco;

public record UpdateGrauParentescoCommand(int Id, string Descricao) : IRequest<string>;