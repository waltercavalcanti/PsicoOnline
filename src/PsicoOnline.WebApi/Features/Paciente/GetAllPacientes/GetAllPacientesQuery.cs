using MediatR;

namespace PsicoOnline.WebApi.Features.Paciente.GetAllPacientes;

public record GetAllPacientesQuery : IRequest<IReadOnlyList<Core.Entities.Paciente>>;