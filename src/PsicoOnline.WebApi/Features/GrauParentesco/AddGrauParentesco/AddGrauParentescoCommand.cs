using MediatR;

namespace PsicoOnline.WebApi.Features.GrauParentesco.AddGrauParentesco;

public record AddGrauParentescoCommand(string Descricao) : IRequest<Core.Entities.GrauParentesco>;