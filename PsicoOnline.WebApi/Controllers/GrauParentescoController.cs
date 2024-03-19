using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using PsicoOnline.Core.DTO;
using PsicoOnline.Core.Interfaces;
using PsicoOnline.Infrastructure.Logging;

namespace PsicoOnline.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GrauParentescoController(IGrauParentescoRepository grauParentescoRepository) : ControllerBase
{
	private readonly IAppLogger<GrauParentescoController> _appLogger = new AppLogger<GrauParentescoController>();

	[HttpGet]
	[Route("GetAll")]
	[EnableQuery]
	public async Task<ActionResult> GetAllGrausParentescoAsync()
	{
		var grausParentesco = await grauParentescoRepository.GetAllGrausParentescoAsync();

		return grausParentesco == null || !grausParentesco.Any()
			? NotFound("Não há graus de parentesco cadastrados.")
			: Ok(grausParentesco);
	}

	[HttpGet]
	[Route("GetById/{id}")]
	public async Task<ActionResult> GetGrauParentescoByIdAsync(int id)
	{
		var grauParentesco = await grauParentescoRepository.GetGrauParentescoByIdAsync(id);

		return grauParentesco == null
			? NotFound($"Não há grau de parentesco cadastrado com o id {id}.")
			: Ok(grauParentesco);
	}

	[HttpPost]
	[Route("Add")]
	public async Task<ActionResult> AddGrauParentescoAsync(GrauParentescoAddDTO grauParentescoDTO)
	{
		var grauParentesco = await grauParentescoRepository.AddGrauParentescoAsync(grauParentescoDTO);

		return Ok(grauParentesco);
	}

	[HttpDelete]
	[Route("DeleteAll")]
	public async Task<ActionResult> DeleteAllGrausParentescoAsync()
	{
		await grauParentescoRepository.DeleteAllGrausParentescoAsync();

		return Ok("Todos os graus de parentesco foram excluídos com sucesso.");
	}

	[HttpDelete]
	[Route("Delete/{id}")]
	public async Task<ActionResult> DeleteGrauParentescoAsync(int id)
	{
		try
		{
			await grauParentescoRepository.DeleteGrauParentescoAsync(id);

			return Ok("Grau de parentesco excluído com sucesso.");
		}
		catch (Exception ex)
		{
			return BadRequest(ex.Message);
		}
	}

	[HttpPut]
	[Route("Update")]
	public async Task<ActionResult> UpdateGrauParentescoAsync(GrauParentescoUpdateDTO grauParentescoDTO)
	{
		try
		{
			await grauParentescoRepository.UpdateGrauParentescoAsync(grauParentescoDTO);

			return Ok("Grau de parentesco atualizado com sucesso.");
		}
		catch (Exception ex)
		{
			return BadRequest(ex.Message);
		}
	}
}