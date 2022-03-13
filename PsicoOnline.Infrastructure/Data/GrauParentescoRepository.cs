using PsicoOnline.Core.DTO;
using PsicoOnline.Core.Entities;
using PsicoOnline.Core.Interfaces;
using PsicoOnline.Infrastructure.Mapper;

namespace PsicoOnline.Infrastructure.Data
{
    public class GrauParentescoRepository : EFRepository<GrauParentesco, int>, IGrauParentescoRepository
    {
        public GrauParentescoRepository(EFContext db) : base(db) { }

        public async Task<GrauParentesco> AddGrauParentesco(GrauParentescoDTO grauParentescoDTO)
        {
            if (grauParentescoDTO == null)
            {
                throw new ArgumentNullException(nameof(grauParentescoDTO));
            }

            var grauParentesco = GrauParentescoMapper.Convert(grauParentescoDTO);

            await Add(grauParentesco);

            return grauParentesco;
        }

        public async Task DeleteAllGrausParentesco()
        {
            var grausParentesco = await GetAll();

            await DeleteAll((List<GrauParentesco>)grausParentesco);
        }

        public async Task DeleteGrauParentesco(int id)
        {
            if (!GrauParentescoExists(id))
            {
                throw new Exception($"Grau de parentesco Id {id} não encontrado.");
            }

            var grauParentesco = await GetById(id);

            await Delete(grauParentesco);
        }

        public async Task<IReadOnlyList<GrauParentesco>> GetAllGrausParentesco()
        {
            return await GetAll();
        }

        public async Task<GrauParentesco> GetGrauParentescoById(int id)
        {
            return await GetById(id);
        }

        public bool GrauParentescoExists(int id) => _db.GrauParentesco.Any(gp => gp.Id == id);

        public async Task UpdateGrauParentesco(GrauParentescoDTO grauParentescoDTO)
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

            await Update(grauParentesco);
        }
    }
}