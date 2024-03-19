using PsicoOnline.Core.DTO;
using PsicoOnline.Core.Entities;

namespace PsicoOnline.Core.Interfaces;

public interface ISessaoRepository
{
	Task<Sessao> GetSessaoByIdAsync(int id);

	Task<IReadOnlyList<Sessao>> GetAllSessoesAsync();

	Task<IReadOnlyList<Sessao>> GetSessoesByPacienteIdDataAsync(SessaoFilterDTO sessaoDTO);

	Task<Sessao> AddSessaoAsync(SessaoAddDTO sessaoDTO);

	Task UpdateSessaoAsync(SessaoUpdateDTO sessaoDTO);

	Task DeleteSessaoAsync(int id);

	Task DeleteAllSessoesAsync();

	bool SessaoExists(int id);
}