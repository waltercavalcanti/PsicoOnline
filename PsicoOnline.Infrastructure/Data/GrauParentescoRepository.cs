using PsicoOnline.Core.DTO;
using PsicoOnline.Core.Entities;
using PsicoOnline.Core.Exceptions;
using PsicoOnline.Core.Interfaces;
using PsicoOnline.Infrastructure.Mapper;

namespace PsicoOnline.Infrastructure.Data
{
    public class GrauParentescoRepository : EFRepository<GrauParentesco, int>, IGrauParentescoRepository
    {
        public GrauParentescoRepository(EFContext db) : base(db) { }

        public async Task<GrauParentesco> AddGrauParentescoAsync(GrauParentescoDTO grauParentescoDTO)
        {
            if (grauParentescoDTO == null)
            {
                throw new ArgumentNullException(nameof(grauParentescoDTO));
            }

            var grauParentesco = GrauParentescoMapper.Convert(grauParentescoDTO);

            await AddAsync(grauParentesco);

            return grauParentesco;
        }

        public async Task DeleteAllGrausParentescoAsync()
        {
            var grausParentesco = await GetAllAsync();

            await DeleteAllAsync((List<GrauParentesco>)grausParentesco);
        }

        public async Task DeleteGrauParentescoAsync(int id)
        {
            if (!GrauParentescoExists(id))
            {
                throw new GrauParentescoNaoExisteException(id);
            }

            var grauParentesco = await GetByIdAsync(id);

            await DeleteAsync(grauParentesco);
        }

        public async Task<IReadOnlyList<GrauParentesco>> GetAllGrausParentescoAsync()
        {
            return await GetAllAsync();
        }

        public async Task<GrauParentesco> GetGrauParentescoByIdAsync(int id)
        {
            return await GetByIdAsync(id);
        }

        public bool GrauParentescoExists(int id) => _db.GrauParentesco.Any(gp => gp.Id == id);

        public async Task UpdateGrauParentescoAsync(GrauParentescoDTO grauParentescoDTO)
        {
            if (grauParentescoDTO == null)
            {
                throw new ArgumentNullException(nameof(grauParentescoDTO));
            }

            var grauParentescoId = ((GrauParentescoUpdateDTO)grauParentescoDTO).Id;

            if (!GrauParentescoExists(grauParentescoId))
            {
                throw new GrauParentescoNaoExisteException(grauParentescoId);
            }

            var grauParentesco = GrauParentescoMapper.Convert(grauParentescoDTO);

            await UpdateAsync(grauParentesco);
        }
    }
}