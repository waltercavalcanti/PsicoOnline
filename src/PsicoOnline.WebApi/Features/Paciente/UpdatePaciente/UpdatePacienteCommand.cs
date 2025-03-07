using MediatR;

namespace PsicoOnline.WebApi.Features.Paciente.UpdatePaciente;

public record UpdatePacienteCommand(int Id, string Nome, DateTime DataNascimento, string Telefone, char Genero) : IRequest<string>;