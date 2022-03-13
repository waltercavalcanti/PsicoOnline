using PsicoOnline.Core.DTO;
using PsicoOnline.Core.Entities;
using PsicoOnline.Core.Interfaces;
using PsicoOnline.Infrastructure.Mapper;

namespace PsicoOnline.Infrastructure.Data
{
    public class SessaoRepository : EFRepository<Sessao, int>, ISessaoRepository
    {
        public SessaoRepository(EFContext db) : base(db) { }

        public async Task<Sessao> AddSessao(SessaoDTO sessaoDTO)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAllSessoes()
        {
            throw new NotImplementedException();
        }

        public async Task DeleteSessao(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<Sessao>> GetAllSessoes()
        {
            throw new NotImplementedException();
        }

        public async Task<Sessao> GetSessaoById(int id)
        {
            throw new NotImplementedException();
        }

        public bool SessaoExists(int id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateSessao(SessaoDTO sessaoDTO)
        {
            throw new NotImplementedException();
        }
    }
}