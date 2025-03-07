using MediatR;

namespace PsicoOnline.WebApi.Features.Paciente.GetPacienteById;

public record GetPacienteByIdQuery(int Id) : IRequest<Core.Entities.Paciente>;