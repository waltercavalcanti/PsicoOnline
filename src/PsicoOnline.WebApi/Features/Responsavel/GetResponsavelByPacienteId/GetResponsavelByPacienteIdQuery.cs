using MediatR;

namespace PsicoOnline.WebApi.Features.Responsavel.GetResponsavelByPacienteId;

public record GetResponsavelByPacienteIdQuery(int Id) : IRequest<Core.Entities.Responsavel>;