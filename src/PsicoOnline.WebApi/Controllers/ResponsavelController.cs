using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using PsicoOnline.Core.DTO;
using PsicoOnline.Core.Entities;
using PsicoOnline.Core.Interfaces;
using System.Linq.Expressions;

namespace PsicoOnline.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ResponsavelController(IResponsavelRepository responsavelRepository) : ControllerBase
{
	[HttpGet]
	[Route("GetAll")]
	[EnableQuery]
	public async Task<ActionResult> GetAllResponsaveisAsync()
	{
		var responsaveis = await responsavelRepository.GetAllResponsaveisAsync();

		return Ok(responsaveis);
	}

	[HttpGet]
	[Route("GetById/{id}")]
	public async Task<ActionResult> GetResponsavelByIdAsync(int id)
	{
		var responsavel = await responsavelRepository.GetResponsavelByIdAsync(id) ?? new();

		return Ok(responsavel);
	}

	[HttpGet]
	[Route("GetByPacienteId/{id}")]
	public async Task<ActionResult> GetResponsavelByPacienteIdAsync(int id)
	{
		Expression<Func<Responsavel, bool>> where = responsavel => responsavel.PacienteId == id;

		var responsaveis = await responsavelRepository.GetResponsaveisWhereAsync(where);

		return Ok(responsaveis.FirstOrDefault() ?? new());
	}

	[HttpPost]
	[Route("Add")]
	public async Task<ActionResult> AddResponsavelAsync(ResponsavelAddDTO responsavelDTO)
	{
		var responsavel = await responsavelRepository.AddResponsavelAsync(responsavelDTO);

		return Ok(responsavel);
	}

	[HttpDelete]
	[Route("Delete/{id}")]
	public async Task<ActionResult> DeleteResponsavelAsync(int id)
	{
		try
		{
			await responsavelRepository.DeleteResponsavelAsync(id);

			return Ok("Responsável excluído com sucesso.");
		}
		catch (Exception ex)
		{
			return BadRequest(ex.Message);
		}
	}

	[HttpPut]
	[Route("Update")]
	public async Task<ActionResult> UpdateResponsavelAsync(ResponsavelUpdateDTO responsavelDTO)
	{
		try
		{
			await responsavelRepository.UpdateResponsavelAsync(responsavelDTO);

			return Ok("Responsável atualizado com sucesso.");
		}
		catch (Exception ex)
		{
			return BadRequest(ex.Message);
		}
	}
}