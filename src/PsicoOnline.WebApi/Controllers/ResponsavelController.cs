using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using PsicoOnline.Core.Interfaces;
using PsicoOnline.Infrastructure.Logging;
using PsicoOnline.WebApi.Features.Responsavel.AddResponsavel;
using PsicoOnline.WebApi.Features.Responsavel.DeleteResponsavel;
using PsicoOnline.WebApi.Features.Responsavel.GetAllResponsaveis;
using PsicoOnline.WebApi.Features.Responsavel.GetResponsavelById;
using PsicoOnline.WebApi.Features.Responsavel.UpdateResponsavel;

namespace PsicoOnline.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ResponsavelController(ISender sender) : ControllerBase
{
	private readonly IAppLogger<ResponsavelController> _appLogger = new AppLogger<ResponsavelController>();

	[HttpGet]
	[Route("GetAll")]
	[EnableQuery]
	public async Task<ActionResult> GetAllResponsaveisAsync()
	{
		var responsaveis = await sender.Send(new GetAllResponsaveisQuery());

		return responsaveis == null || !responsaveis.Any()
			? NotFound("Não há responsáveis cadastrados.")
			: Ok(responsaveis);
	}

	[HttpGet]
	[Route("GetById/{id}")]
	public async Task<ActionResult> GetResponsavelByIdAsync(int id)
	{
		var responsavel = await sender.Send(new GetResponsavelByIdQuery(id));

		return responsavel == null
			? NotFound($"Não há responsável cadastrado com o id {id}.")
			: Ok(responsavel);
	}

	[HttpPost]
	[Route("Add")]
	public async Task<ActionResult> AddResponsavelAsync(AddResponsavelCommand addResponsavelCommand)
	{
		var responsavel = await sender.Send(addResponsavelCommand);

		return Ok(responsavel);
	}

	[HttpDelete]
	[Route("Delete/{id}")]
	public async Task<ActionResult> DeleteResponsavelAsync(int id)
	{
		try
		{
			var retorno = await sender.Send(new DeleteResponsavelCommand(id));

			return Ok(retorno);
		}
		catch (Exception ex)
		{
			return BadRequest(ex.Message);
		}
	}

	[HttpPut]
	[Route("Update")]
	public async Task<ActionResult> UpdateResponsavelAsync(UpdateResponsavelCommand updateResponsavelCommand)
	{
		try
		{
			var retorno = await sender.Send(updateResponsavelCommand);

			return Ok(retorno);
		}
		catch (Exception ex)
		{
			return BadRequest(ex.Message);
		}
	}
}