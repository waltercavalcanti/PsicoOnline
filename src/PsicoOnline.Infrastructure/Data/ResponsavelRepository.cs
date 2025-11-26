using Mapster;
using PsicoOnline.Core.DTOs.Responsavel;
using PsicoOnline.Core.Entities;
using PsicoOnline.Core.Exceptions;
using PsicoOnline.Infrastructure.Data.Interfaces;
using System.Linq.Expressions;

namespace PsicoOnline.Infrastructure.Data;

public class ResponsavelRepository(EFContext db) : EFRepository<Responsavel, int>(db), IResponsavelRepository
{
	public async Task<Responsavel> AddResponsavelAsync(ResponsavelAddDTO responsavelDTO)
	{
		ArgumentNullException.ThrowIfNull(responsavelDTO);

		var responsavel = responsavelDTO.Adapt<Responsavel>();

		await AddAsync(responsavel);

		return responsavel;
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

	public async Task<IReadOnlyList<Responsavel>> GetResponsaveisWhereAsync(Expression<Func<Responsavel, bool>> where)
	{
		var responsaveis = await GetWhereAsync(where);

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
		ArgumentNullException.ThrowIfNull(responsavelDTO);

		if (!ResponsavelExists(responsavelDTO.Id))
		{
			throw new ResponsavelNaoExisteException(responsavelDTO.Id);
		}

		var responsavel = responsavelDTO.Adapt<Responsavel>();

		await UpdateAsync(responsavel);
	}
}