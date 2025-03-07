using MediatR;

namespace PsicoOnline.WebApi.Features.Paciente.AddPaciente;

public record AddPacienteCommand(string Nome, DateTime DataNascimento, string Telefone, char Genero) : IRequest<Core.Entities.Paciente>;