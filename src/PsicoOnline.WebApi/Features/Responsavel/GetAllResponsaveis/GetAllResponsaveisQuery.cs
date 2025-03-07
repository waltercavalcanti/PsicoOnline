using MediatR;

namespace PsicoOnline.WebApi.Features.Responsavel.GetAllResponsaveis;

public record GetAllResponsaveisQuery : IRequest<IReadOnlyList<Core.Entities.Responsavel>>;