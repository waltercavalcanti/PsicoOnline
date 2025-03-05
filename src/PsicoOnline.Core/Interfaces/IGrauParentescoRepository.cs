using PsicoOnline.Core.DTO;
using PsicoOnline.Core.Entities;

namespace PsicoOnline.Core.Interfaces;

public interface IGrauParentescoRepository
{
	Task<GrauParentesco> GetGrauParentescoByIdAsync(int id);

	Task<IReadOnlyList<GrauParentesco>> GetAllGrausParentescoAsync();

	Task<GrauParentesco> AddGrauParentescoAsync(GrauParentescoAddDTO grauParentescoDTO);

	Task UpdateGrauParentescoAsync(GrauParentescoUpdateDTO grauParentescoDTO);

	Task DeleteGrauParentescoAsync(int id);

	bool GrauParentescoExists(int id);
}