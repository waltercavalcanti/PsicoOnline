using MediatR;

namespace PsicoOnline.WebApi.Features.Responsavel.DeleteResponsavel;

public record DeleteResponsavelCommand(int Id) : IRequest<string>;