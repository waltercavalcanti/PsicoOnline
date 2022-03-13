using PsicoOnline.Core.DTO;
using PsicoOnline.Core.Entities;

namespace PsicoOnline.Core.Interfaces
{
    public interface ISessaoRepository
    {
        Task<Sessao> GetSessaoById(int id);

        Task<IReadOnlyList<Sessao>> GetAllSessoes();

        Task<Sessao> AddSessao(SessaoDTO sessaoDTO);

        Task UpdateSessao(SessaoDTO sessaoDTO);

        Task DeleteSessao(int id);

        Task DeleteAllSessoes();

        bool SessaoExists(int id);
    }
}