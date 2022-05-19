using PsicoOnline.Core.DTO;
using PsicoOnline.Core.Entities;

namespace PsicoOnline.Infrastructure.Mapper
{
    public static class GrauParentescoMapper
    {
        public static GrauParentesco Convert(GrauParentescoDTO grauParentescoDTO)
        {
            if (grauParentescoDTO == null)
            {
                return null;
            }

            var grauParentesco = new GrauParentesco();

            if (grauParentescoDTO is GrauParentescoAddDTO grauParentescoAddDTO)
            {
                grauParentesco.Descricao = grauParentescoAddDTO.Descricao;
            }
            else if (grauParentescoDTO is GrauParentescoUpdateDTO grauParentescoUpdateDTO)
            {
                grauParentesco.Id = grauParentescoUpdateDTO.Id;
                grauParentesco.Descricao = grauParentescoUpdateDTO.Descricao;
            }

            return grauParentesco;
        }
    }
}