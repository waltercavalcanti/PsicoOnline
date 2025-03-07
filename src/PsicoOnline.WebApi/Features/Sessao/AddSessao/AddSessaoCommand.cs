using MediatR;

namespace PsicoOnline.WebApi.Features.Sessao.AddSessao;

public record AddSessaoCommand(int PacienteId, DateTime DataSessao, string Anotacao) : IRequest<Core.Entities.Sessao>;