using PsicoOnline.Core.DTO;
using PsicoOnline.Core.Entities;
using System.Linq.Expressions;

namespace PsicoOnline.Core.Interfaces;

public interface IGrauParentescoRepository
{
	Task<GrauParentesco> GetGrauParentescoByIdAsync(int id);

	Task<IReadOnlyList<GrauParentesco>> GetAllGrausParentescoAsync();

	Task<IReadOnlyList<GrauParentesco>> GetGrausParentescoWhereAsync(Expression<Func<GrauParentesco, bool>> where);

	Task<GrauParentesco> AddGrauParentescoAsync(GrauParentescoAddDTO grauParentescoDTO);

	Task UpdateGrauParentescoAsync(GrauParentescoUpdateDTO grauParentescoDTO);

	Task DeleteGrauParentescoAsync(int id);

	bool GrauParentescoExists(int id);
}