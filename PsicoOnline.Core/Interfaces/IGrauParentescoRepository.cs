using PsicoOnline.Core.DTO;
using PsicoOnline.Core.Entities;

namespace PsicoOnline.Core.Interfaces
{
    public interface IGrauParentescoRepository
    {
        GrauParentesco GetGrauParentescoById(int id);

        IReadOnlyList<GrauParentesco> GetAllGrausParentesco();

        GrauParentesco AddGrauParentesco(GrauParentescoDTO grauParentescoDTO);

        void UpdateGrauParentesco(GrauParentescoDTO grauParentescoDTO);

        void DeleteGrauParentesco(int id);

        void DeleteAllGrausParentesco();

        bool GrauParentescoExists(int id);
    }
}