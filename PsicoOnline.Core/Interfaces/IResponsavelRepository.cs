using PsicoOnline.Core.DTO;
using PsicoOnline.Core.Entities;

namespace PsicoOnline.Core.Interfaces;

public interface IResponsavelRepository
{
	Task<Responsavel> GetResponsavelByIdAsync(int id);

	Task<IReadOnlyList<Responsavel>> GetAllResponsaveisAsync();

	Task<Responsavel> AddResponsavelAsync(ResponsavelAddDTO responsavelDTO);

	Task UpdateResponsavelAsync(ResponsavelUpdateDTO responsavelDTO);

	Task DeleteResponsavelAsync(int id);

	Task DeleteAllResponsaveisAsync();

	bool ResponsavelExists(int id);
}