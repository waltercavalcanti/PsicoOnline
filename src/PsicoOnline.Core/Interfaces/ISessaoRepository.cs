using PsicoOnline.Core.DTO;
using PsicoOnline.Core.Entities;
using System.Linq.Expressions;

namespace PsicoOnline.Core.Interfaces;

public interface ISessaoRepository
{
	Task<Sessao> GetSessaoByIdAsync(int id);

	Task<IReadOnlyList<Sessao>> GetAllSessoesAsync();

	Task<IReadOnlyList<Sessao>> GetSessoesWhereAsync(Expression<Func<Sessao, bool>> where);

	Task<IReadOnlyList<Sessao>> GetSessoesByPacienteIdDataAsync(SessaoFilterDTO sessaoDTO);

	Task<Sessao> AddSessaoAsync(SessaoAddDTO sessaoDTO);

	Task UpdateSessaoAsync(SessaoUpdateDTO sessaoDTO);

	Task DeleteSessaoAsync(int id);

	bool SessaoExists(int id);
}