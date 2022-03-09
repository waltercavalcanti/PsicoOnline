using PsicoOnline.Core.DTO;
using PsicoOnline.Core.Entities;

namespace PsicoOnline.Core.Interfaces
{
    public interface ISessaoRepository
    {
        Sessao GetSessaoById(int id);

        IReadOnlyList<Sessao> GetAllSessoes();

        Sessao AddSessao(SessaoDTO sessaoDTO);

        void UpdateSessao(SessaoDTO sessaoDTO);

        void DeleteSessao(SessaoDTO sessaoDTO);

        void DeleteAllSessoes(List<SessaoDTO> sessoesDTO);

        bool SessaoExists(int id);
    }
}