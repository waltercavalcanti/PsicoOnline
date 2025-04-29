using PsicoOnline.Core.DTO;
using PsicoOnline.Core.Entities;
using System.Linq.Expressions;

namespace PsicoOnline.Core.Interfaces;

public interface IResponsavelRepository
{
	Task<Responsavel> GetResponsavelByIdAsync(int id);

	Task<IReadOnlyList<Responsavel>> GetAllResponsaveisAsync();

	Task<IReadOnlyList<Responsavel>> GetResponsaveisWhereAsync(Expression<Func<Responsavel, bool>> where);

	Task<Responsavel> AddResponsavelAsync(ResponsavelAddDTO responsavelDTO);

	Task UpdateResponsavelAsync(ResponsavelUpdateDTO responsavelDTO);

	Task DeleteResponsavelAsync(int id);

	bool ResponsavelExists(int id);
}