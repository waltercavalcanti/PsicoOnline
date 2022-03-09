using PsicoOnline.Core.DTO;
using PsicoOnline.Core.Entities;
using PsicoOnline.Core.Interfaces;
using PsicoOnline.Infrastructure.Mapper;

namespace PsicoOnline.Infrastructure.Data
{
    public class GrauParentescoRepository : EFRepository<GrauParentesco, int>, IGrauParentescoRepository
    {
        public GrauParentescoRepository(EFContext db) : base(db) { }

        public GrauParentesco AddGrauParentesco(GrauParentescoDTO grauParentescoDTO)
        {
            if (grauParentescoDTO == null)
            {
                throw new ArgumentNullException(nameof(grauParentescoDTO));
            }

            var grauParentesco = GrauParentescoMapper.Convert(grauParentescoDTO);

            Add(grauParentesco);

            return grauParentesco;
        }

        public void DeleteAllGrausParentesco()
        {
            DeleteAll((List<GrauParentesco>)GetAll());
        }

        public void DeleteGrauParentesco(int id)
        {
            if (!GrauParentescoExists(id))
            {
                throw new Exception($"Grau de parentesco Id {id} não encontrado.");
            }

            var grauParentesco = GetById(id);

            Delete(grauParentesco);
        }

        public IReadOnlyList<GrauParentesco> GetAllGrausParentesco()
        {
            return GetAll();
        }

        public GrauParentesco GetGrauParentescoById(int id)
        {
            return GetById(id);
        }

        public bool GrauParentescoExists(int id)
        {
            return db.GrauParentesco.Any(grauParentesco => grauParentesco.Id == id);
        }

        public void UpdateGrauParentesco(GrauParentescoDTO grauParentescoDTO)
        {
            if (grauParentescoDTO == null)
            {
                throw new ArgumentNullException(nameof(grauParentescoDTO));
            }

            if (!GrauParentescoExists(grauParentescoDTO.Id))
            {
                throw new Exception($"Grau de parentesco Id {grauParentescoDTO.Id} não encontrado.");
            }

            var grauParentesco = GrauParentescoMapper.Convert(grauParentescoDTO);

            Update(grauParentesco);
        }
    }
}