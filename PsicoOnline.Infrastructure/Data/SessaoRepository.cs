using AutoMapper;
using PsicoOnline.Core.DTO;
using PsicoOnline.Core.Entities;
using PsicoOnline.Core.Exceptions;
using PsicoOnline.Core.Interfaces;

namespace PsicoOnline.Infrastructure.Data;

public class SessaoRepository : EFRepository<Sessao, int>, ISessaoRepository
{
    private readonly IMapper _mapper;

    public SessaoRepository(EFContext db, IMapper mapper) : base(db)
    {
        _mapper = mapper;
    }

    public async Task<Sessao> AddSessaoAsync(SessaoAddDTO sessaoDTO)
    {
        if (sessaoDTO == null)
        {
            throw new ArgumentNullException(nameof(sessaoDTO));
        }

        var sessao = _mapper.Map<Sessao>(sessaoDTO);

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
            sessao.Paciente = _db.Paciente.FirstOrDefault(p => p.Id == sessao.PacienteId);
        }

        return sessao;
    }

    public async Task<IReadOnlyList<Sessao>> GetSessoesByPacienteIdDataAsync(SessaoFilterDTO sessaoDTO)
    {
        var sessoes = await GetAllAsync();

        if (sessoes != null && sessoes.Count > 0)
        {
            if (sessaoDTO.PacienteId != null)
            {
                sessoes = (IReadOnlyList<Sessao>)sessoes.Where(s => s.PacienteId == sessaoDTO.PacienteId);
            }

            if (sessaoDTO.DataSessao != null)
            {
                sessoes = (IReadOnlyList<Sessao>)sessoes.Where(s => s.DataSessao == sessaoDTO.DataSessao);
            }

            foreach (var s in sessoes)
            {
                s.Paciente = _db.Paciente.FirstOrDefault(p => p.Id == s.PacienteId);
            }
        }

        return sessoes;
    }

    public bool SessaoExists(int id) => _db.Sessao.Any(s => s.Id == id);

    public async Task UpdateSessaoAsync(SessaoUpdateDTO sessaoDTO)
    {
        if (sessaoDTO == null)
        {
            throw new ArgumentNullException(nameof(sessaoDTO));
        }

        var sessaoId = sessaoDTO.Id;

        if (!SessaoExists(sessaoId))
        {
            throw new SessaoNaoExisteException(sessaoId);
        }

        var sessao = _mapper.Map<Sessao>(sessaoDTO);

        await UpdateAsync(sessao);
    }
}