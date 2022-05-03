using PsicoOnline.Core.DTO;
using PsicoOnline.Core.Entities;
using PsicoOnline.Core.Interfaces;
using PsicoOnline.Infrastructure.Mapper;

namespace PsicoOnline.Infrastructure.Data
{
    public class ResponsavelRepository : EFRepository<Responsavel, int>, IResponsavelRepository
    {
        public ResponsavelRepository(EFContext db) : base(db) { }

        public async Task<Responsavel> AddResponsavelAsync(ResponsavelDTO responsavelDTO)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAllResponsaveisAsync()
        {
            throw new NotImplementedException();
        }

        public async Task DeleteResponsavelAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<Responsavel>> GetAllResponsaveisAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Responsavel> GetResponsavelByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public bool ResponsavelExists(int id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateResponsavelAsync(ResponsavelDTO responsavelDTO)
        {
            throw new NotImplementedException();
        }
    }
}