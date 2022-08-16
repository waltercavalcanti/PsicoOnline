using AutoMapper;
using PsicoOnline.Core.DTO;
using PsicoOnline.Core.Entities;
using PsicoOnline.Core.Exceptions;
using PsicoOnline.Core.Interfaces;

namespace PsicoOnline.Infrastructure.Data
{
    public class GrauParentescoRepository : EFRepository<GrauParentesco, int>, IGrauParentescoRepository
    {
        private readonly IMapper _mapper;

        public GrauParentescoRepository(EFContext db, IMapper mapper) : base(db)
        {
            _mapper = mapper;
        }

        public async Task<GrauParentesco> AddGrauParentescoAsync(GrauParentescoAddDTO grauParentescoDTO)
        {
            if (grauParentescoDTO == null)
            {
                throw new ArgumentNullException(nameof(grauParentescoDTO));
            }

            var grauParentesco = _mapper.Map<GrauParentesco>(grauParentescoDTO);

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

        public async Task UpdateGrauParentescoAsync(GrauParentescoUpdateDTO grauParentescoDTO)
        {
            if (grauParentescoDTO == null)
            {
                throw new ArgumentNullException(nameof(grauParentescoDTO));
            }

            var grauParentescoId = grauParentescoDTO.Id;

            if (!GrauParentescoExists(grauParentescoId))
            {
                throw new GrauParentescoNaoExisteException(grauParentescoId);
            }

            var grauParentesco = _mapper.Map<GrauParentesco>(grauParentescoDTO);

            await UpdateAsync(grauParentesco);
        }
    }
}