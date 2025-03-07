using MediatR;

namespace PsicoOnline.WebApi.Features.Responsavel.AddResponsavel;

public record AddResponsavelCommand(string Nome, DateTime DataNascimento, string Telefone, char Genero, int PacienteId, int GrauParentescoId) : IRequest<Core.Entities.Responsavel>;