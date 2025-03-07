using MediatR;

namespace PsicoOnline.WebApi.Features.Sessao.GetSessoesByPacienteIdData;

public record GetSessoesByPacienteIdDataQuery(int? PacienteId, DateTime? DataSessao) : IRequest<IReadOnlyList<Core.Entities.Sessao>>;