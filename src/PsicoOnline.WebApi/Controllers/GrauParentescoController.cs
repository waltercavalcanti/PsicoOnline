using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using PsicoOnline.Core.Interfaces;
using PsicoOnline.Infrastructure.Logging;
using PsicoOnline.WebApi.Features.GrauParentesco.AddGrauParentesco;
using PsicoOnline.WebApi.Features.GrauParentesco.DeleteGrauParentesco;
using PsicoOnline.WebApi.Features.GrauParentesco.GetAllGrausParentesco;
using PsicoOnline.WebApi.Features.GrauParentesco.GetGrauParentescoById;
using PsicoOnline.WebApi.Features.GrauParentesco.UpdateGrauParentesco;

namespace PsicoOnline.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GrauParentescoController(ISender sender) : ControllerBase
{
	private readonly IAppLogger<GrauParentescoController> _appLogger = new AppLogger<GrauParentescoController>();

	[HttpGet]
	[Route("GetAll")]
	[EnableQuery]
	public async Task<ActionResult> GetAllGrausParentescoAsync()
	{
		var grausParentesco = await sender.Send(new GetAllGrausParentescoQuery());

		return Ok(grausParentesco);
	}

	[HttpGet]
	[Route("GetById/{id}")]
	public async Task<ActionResult> GetGrauParentescoByIdAsync(int id)
	{
		var grauParentesco = await sender.Send(new GetGrauParentescoByIdQuery(id)) ?? new();

		return Ok(grauParentesco);
	}

	[HttpPost]
	[Route("Add")]
	public async Task<ActionResult> AddGrauParentescoAsync(AddGrauParentescoCommand addGrauParentescoCommand)
	{
		var grauParentesco = await sender.Send(addGrauParentescoCommand);

		return Ok(grauParentesco);
	}

	[HttpDelete]
	[Route("Delete/{id}")]
	public async Task<ActionResult> DeleteGrauParentescoAsync(int id)
	{
		try
		{
			var retorno = await sender.Send(new DeleteGrauParentescoCommand(id));

			return Ok(retorno);
		}
		catch (Exception ex)
		{
			return BadRequest(ex.Message);
		}
	}

	[HttpPut]
	[Route("Update")]
	public async Task<ActionResult> UpdateGrauParentescoAsync(UpdateGrauParentescoCommand updateGrauParentescoCommand)
	{
		try
		{
			var retorno = await sender.Send(updateGrauParentescoCommand);

			return Ok(retorno);
		}
		catch (Exception ex)
		{
			return BadRequest(ex.Message);
		}
	}
}