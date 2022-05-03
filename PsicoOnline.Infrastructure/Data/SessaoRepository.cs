using PsicoOnline.Core.DTO;
using PsicoOnline.Core.Entities;
using PsicoOnline.Core.Interfaces;
using PsicoOnline.Infrastructure.Mapper;

namespace PsicoOnline.Infrastructure.Data
{
    public class SessaoRepository : EFRepository<Sessao, int>, ISessaoRepository
    {
        public SessaoRepository(EFContext db) : base(db) { }

        public async Task<Sessao> AddSessaoAsync(SessaoDTO sessaoDTO)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAllSessoesAsync()
        {
            throw new NotImplementedException();
        }

        public async Task DeleteSessaoAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<Sessao>> GetAllSessoesAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Sessao> GetSessaoByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public bool SessaoExists(int id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateSessaoAsync(SessaoDTO sessaoDTO)
        {
            throw new NotImplementedException();
        }
    }
}