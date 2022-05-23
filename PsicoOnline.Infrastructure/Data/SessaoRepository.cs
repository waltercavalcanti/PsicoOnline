using PsicoOnline.Core.DTO;
using PsicoOnline.Core.Entities;
using PsicoOnline.Core.Exceptions;
using PsicoOnline.Core.Interfaces;
using PsicoOnline.Infrastructure.Mapper;

namespace PsicoOnline.Infrastructure.Data
{
    public class SessaoRepository : EFRepository<Sessao, int>, ISessaoRepository
    {
        public SessaoRepository(EFContext db) : base(db) { }

        public async Task<Sessao> AddSessaoAsync(SessaoDTO sessaoDTO)
        {
            if (sessaoDTO == null)
            {
                throw new ArgumentNullException(nameof(sessaoDTO));
            }

            var sessao = SessaoMapper.Convert(sessaoDTO);

            await AddAsync(sessao);

            return sessao;
        }

        public async Task DeleteAllSessoesAsync()
        {
            var sessoes = await GetAllAsync();

            await DeleteAllAsync((List<Sessao>)sessoes);
        }

        public async Task DeleteSessaoAsync(int id)
        {
            if (!SessaoExists(id))
            {
                throw new SessaoNaoExisteException(id);
            }

            var sessao = await GetByIdAsync(id);

            await DeleteAsync(sessao);
        }

        public async Task<IReadOnlyList<Sessao>> GetAllSessoesAsync()
        {
            var sessoes = await GetAllAsync();

            foreach (var s in sessoes)
            {
                s.Paciente = _db.Paciente.FirstOrDefault(p => p.Id == s.PacienteId);
            }

            return sessoes;
        }

        public async Task<Sessao> GetSessaoByIdAsync(int id)
        {
            var sessao = await GetByIdAsync(id);

            if (sessao != null)
            {
                sessao.Paciente = _db.Paciente.FirstOrDefault(p => p.Id == id);
            }

            return sessao;
        }

        public bool SessaoExists(int id) => _db.Sessao.Any(s => s.Id == id);

        public async Task UpdateSessaoAsync(SessaoDTO sessaoDTO)
        {
            if (sessaoDTO == null)
            {
                throw new ArgumentNullException(nameof(sessaoDTO));
            }

            var sessaoId = ((SessaoUpdateDTO)sessaoDTO).Id;

            if (!SessaoExists(sessaoId))
            {
                throw new SessaoNaoExisteException(sessaoId);
            }

            var sessao = SessaoMapper.Convert(sessaoDTO);

            await UpdateAsync(sessao);
        }
    }
}