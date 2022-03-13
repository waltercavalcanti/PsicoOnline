using PsicoOnline.Core.DTO;
using PsicoOnline.Core.Entities;
using PsicoOnline.Core.Interfaces;
using PsicoOnline.Infrastructure.Mapper;

namespace PsicoOnline.Infrastructure.Data
{
    public class ResponsavelRepository : EFRepository<Responsavel, int>, IResponsavelRepository
    {
        public ResponsavelRepository(EFContext db) : base(db) { }

        public async Task<Responsavel> AddResponsavel(ResponsavelDTO responsavelDTO)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAllResponsaveis()
        {
            throw new NotImplementedException();
        }

        public async Task DeleteResponsavel(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<Responsavel>> GetAllResponsaveis()
        {
            throw new NotImplementedException();
        }

        public async Task<Responsavel> GetResponsavelById(int id)
        {
            throw new NotImplementedException();
        }

        public bool ResponsavelExists(int id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateResponsavel(ResponsavelDTO responsavelDTO)
        {
            throw new NotImplementedException();
        }
    }
}