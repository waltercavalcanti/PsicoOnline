using MediatR;

namespace PsicoOnline.WebApi.Features.Paciente.DeletePaciente;

public record DeletePacienteCommand(int Id) : IRequest<string>;