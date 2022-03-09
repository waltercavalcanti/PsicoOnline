using PsicoOnline.Core.DTO;
using PsicoOnline.Core.Entities;
using PsicoOnline.Core.Interfaces;
using PsicoOnline.Infrastructure.Mapper;

namespace PsicoOnline.Infrastructure.Data
{
    public class SessaoRepository : EFRepository<Sessao, int>, ISessaoRepository
    {
        public SessaoRepository(EFContext db) : base(db) { }

        public Sessao AddSessao(SessaoDTO sessaoDTO)
        {
            if (sessaoDTO == null)
            {
                throw new ArgumentNullException(nameof(sessaoDTO));
            }

            var sessao = SessaoMapper.Convert(sessaoDTO);

            Add(sessao);

            return sessao;
        }

        public void DeleteAllSessoes(List<SessaoDTO> sessoesDTO)
        {
            if (sessoesDTO == null)
            {
                throw new ArgumentNullException(nameof(sessoesDTO));
            }

            var sessoes = new List<Sessao>();

            sessoesDTO.ForEach(sessaoDTO => sessoes.Add(SessaoMapper.Convert(sessaoDTO)));

            DeleteAll(sessoes);
        }

        public void DeleteSessao(SessaoDTO sessaoDTO)
        {
            if (sessaoDTO == null)
            {
                throw new ArgumentNullException(nameof(sessaoDTO));
            }

            var sessao = SessaoMapper.Convert(sessaoDTO);

            Delete(sessao);
        }

        public IReadOnlyList<Sessao> GetAllSessoes()
        {
            return GetAll();
        }

        public Sessao GetSessaoById(int id)
        {
            return GetById(id);
        }

        public bool SessaoExists(int id)
        {
            return db.Sessao.Any(sessao => sessao.Id == id);
        }

        public void UpdateSessao(SessaoDTO sessaoDTO)
        {
            if (sessaoDTO == null)
            {
                throw new ArgumentNullException(nameof(sessaoDTO));
            }

            if (SessaoExists(sessaoDTO.Id))
            {
                var sessao = SessaoMapper.Convert(sessaoDTO);

                Update(sessao);
            }
        }
    }
}