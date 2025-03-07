using AutoMapper;
using PsicoOnline.Core.DTO;
using PsicoOnline.Core.Entities;
using PsicoOnline.Core.Exceptions;
using PsicoOnline.Core.Interfaces;

namespace PsicoOnline.Infrastructure.Data;

public class GrauParentescoRepository(EFContext db, IMapper mapper) : EFRepository<GrauParentesco, int>(db), IGrauParentescoRepository
{
	public async Task<GrauParentesco> AddGrauParentescoAsync(GrauParentescoAddDTO grauParentescoDTO)
	{
		ArgumentNullException.ThrowIfNull(grauParentescoDTO);

		var grauParentesco = mapper.Map<GrauParentesco>(grauParentescoDTO);

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

	public bool GrauParentescoExists(int id) => _db.GrauParentesco.Any(gp => gp.Id == id);

	public async Task UpdateGrauParentescoAsync(GrauParentescoUpdateDTO grauParentescoDTO)
	{
		ArgumentNullException.ThrowIfNull(grauParentescoDTO);

		if (!GrauParentescoExists(grauParentescoDTO.Id))
		{
			throw new GrauParentescoNaoExisteException(grauParentescoDTO.Id);
		}

		var grauParentesco = mapper.Map<GrauParentesco>(grauParentescoDTO);

		await UpdateAsync(grauParentesco);
	}
}