using PsicoOnline.Core.DTO;
using PsicoOnline.Core.Entities;

namespace PsicoOnline.Core.Interfaces
{
    public interface IGrauParentescoRepository
    {
        Task<GrauParentesco> GetGrauParentescoByIdAsync(int id);

        Task<IReadOnlyList<GrauParentesco>> GetAllGrausParentescoAsync();

        Task<GrauParentesco> AddGrauParentescoAsync(GrauParentescoDTO grauParentescoDTO);

        Task UpdateGrauParentescoAsync(GrauParentescoDTO grauParentescoDTO);

        Task DeleteGrauParentescoAsync(int id);

        Task DeleteAllGrausParentescoAsync();

        bool GrauParentescoExists(int id);
    }
}