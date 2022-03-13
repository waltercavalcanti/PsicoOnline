using PsicoOnline.Core.DTO;
using PsicoOnline.Core.Entities;

namespace PsicoOnline.Core.Interfaces
{
    public interface IGrauParentescoRepository
    {
        Task<GrauParentesco> GetGrauParentescoById(int id);

        Task<IReadOnlyList<GrauParentesco>> GetAllGrausParentesco();

        Task<GrauParentesco> AddGrauParentesco(GrauParentescoDTO grauParentescoDTO);

        Task UpdateGrauParentesco(GrauParentescoDTO grauParentescoDTO);

        Task DeleteGrauParentesco(int id);

        Task DeleteAllGrausParentesco();

        bool GrauParentescoExists(int id);
    }
}