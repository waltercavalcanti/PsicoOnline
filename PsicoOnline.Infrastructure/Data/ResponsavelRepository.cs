using AutoMapper;
using PsicoOnline.Core.DTO;
using PsicoOnline.Core.Entities;
using PsicoOnline.Core.Exceptions;
using PsicoOnline.Core.Interfaces;

namespace PsicoOnline.Infrastructure.Data;

public class ResponsavelRepository : EFRepository<Responsavel, int>, IResponsavelRepository
{
    private readonly IMapper _mapper;

    public ResponsavelRepository(EFContext db, IMapper mapper) : base(db)
    {
        _mapper = mapper;
    }

    public async Task<Responsavel> AddResponsavelAsync(ResponsavelAddDTO responsavelDTO)
    {
        if (responsavelDTO == null)
        {
            throw new ArgumentNullException(nameof(responsavelDTO));
        }

        var responsavel = _mapper.Map<Responsavel>(responsavelDTO);

        await AddAsync(responsavel);

        return responsavel;
    }

    public async Task DeleteAllResponsaveisAsync()
    {
        var responsaveis = await GetAllAsync();

        await DeleteAllAsync((List<Responsavel>)responsaveis);
    }

    public async Task DeleteResponsavelAsync(int id)
    {
        if (!ResponsavelExists(id))
        {
            throw new ResponsavelNaoExisteException(id);
        }

        var responsavel = await GetByIdAsync(id);

        await DeleteAsync(responsavel);
    }

    public async Task<IReadOnlyList<Responsavel>> GetAllResponsaveisAsync()
    {
        var responsaveis = await GetAllAsync();

        foreach (var r in responsaveis)
        {
            r.Paciente = _db.Paciente.FirstOrDefault(p => p.Id == r.PacienteId);
            r.GrauParentesco = _db.GrauParentesco.FirstOrDefault(gp => gp.Id == r.GrauParentescoId);
        }

        return responsaveis;
    }

    public async Task<Responsavel> GetResponsavelByIdAsync(int id)
    {
        var responsavel = await GetByIdAsync(id);

        if (responsavel != null)
        {
            responsavel.Paciente = _db.Paciente.FirstOrDefault(p => p.Id == responsavel.PacienteId);
            responsavel.GrauParentesco = _db.GrauParentesco.FirstOrDefault(gp => gp.Id == responsavel.GrauParentescoId);
        }

        return responsavel;
    }

    public bool ResponsavelExists(int id) => _db.Responsavel.Any(r => r.Id == id);

    public async Task UpdateResponsavelAsync(ResponsavelUpdateDTO responsavelDTO)
    {
        if (responsavelDTO == null)
        {
            throw new ArgumentNullException(nameof(responsavelDTO));
        }

        var responsavelId = responsavelDTO.Id;

        if (!ResponsavelExists(responsavelId))
        {
            throw new ResponsavelNaoExisteException(responsavelId);
        }

        var responsavel = _mapper.Map<Responsavel>(responsavelDTO);

        await UpdateAsync(responsavel);
    }
}