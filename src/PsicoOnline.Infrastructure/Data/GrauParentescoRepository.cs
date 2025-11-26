using Mapster;
using PsicoOnline.Core.DTOs.GrauParentesco;
using PsicoOnline.Core.Entities;
using PsicoOnline.Core.Exceptions;
using PsicoOnline.Infrastructure.Data.Interfaces;
using System.Linq.Expressions;

namespace PsicoOnline.Infrastructure.Data;

public class GrauParentescoRepository(EFContext db) : EFRepository<GrauParentesco, int>(db), IGrauParentescoRepository
{
	public async Task<GrauParentesco> AddGrauParentescoAsync(GrauParentescoAddDTO grauParentescoDTO)
	{
		ArgumentNullException.ThrowIfNull(grauParentescoDTO);

		var grauParentesco = grauParentescoDTO.Adapt<GrauParentesco>();

		await AddAsync(grauParentesco);

		return grauParentesco;
	}

	public async Task DeleteGrauParentescoAsync(int id)
	{
		if (!GrauParentescoExists(id))
		{
			throw new GrauParentescoNaoExisteException(id);
		}

		var grauParentesco = await GetByIdAsync(id);

		await DeleteAsync(grauParentesco);
	}

	public async Task<IReadOnlyList<GrauParentesco>> GetAllGrausParentescoAsync() => await GetAllAsync();

	public async Task<GrauParentesco> GetGrauParentescoByIdAsync(int id) => await GetByIdAsync(id);

	public async Task<IReadOnlyList<GrauParentesco>> GetGrausParentescoWhereAsync(Expression<Func<GrauParentesco, bool>> where) => await GetWhereAsync(where);

	public bool GrauParentescoExists(int id) => _db.GrauParentesco.Any(gp => gp.Id == id);

	public async Task UpdateGrauParentescoAsync(GrauParentescoUpdateDTO grauParentescoDTO)
	{
		ArgumentNullException.ThrowIfNull(grauParentescoDTO);

		if (!GrauParentescoExists(grauParentescoDTO.Id))
		{
			throw new GrauParentescoNaoExisteException(grauParentescoDTO.Id);
		}

		var grauParentesco = grauParentescoDTO.Adapt<GrauParentesco>();

		await UpdateAsync(grauParentesco);
	}
}