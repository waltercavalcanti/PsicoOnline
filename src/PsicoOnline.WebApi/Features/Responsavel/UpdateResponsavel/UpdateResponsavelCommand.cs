using MediatR;

namespace PsicoOnline.WebApi.Features.Responsavel.UpdateResponsavel;

public record UpdateResponsavelCommand(int Id, string Nome, DateTime DataNascimento, string Telefone, char Genero, int PacienteId, int GrauParentescoId) : IRequest<string>;