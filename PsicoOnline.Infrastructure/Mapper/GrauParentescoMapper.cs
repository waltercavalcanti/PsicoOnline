using PsicoOnline.Core.DTO;
using PsicoOnline.Core.Entities;

namespace PsicoOnline.Infrastructure.Mapper
{
    public static class GrauParentescoMapper
    {
        public static GrauParentesco Convert(GrauParentescoDTO grauParentesco)
        {
            if (grauParentesco == null)
            {
                return null;
            }

            return new GrauParentesco
            {
                Id = grauParentesco.Id,
                Descricao = grauParentesco.Descricao
            };
        }
    }
}