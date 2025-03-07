using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using PsicoOnline.Core.Interfaces;
using PsicoOnline.Infrastructure.Logging;
using PsicoOnline.WebApi.Features.Sessao.AddSessao;
using PsicoOnline.WebApi.Features.Sessao.DeleteSessao;
using PsicoOnline.WebApi.Features.Sessao.GetAllSessoes;
using PsicoOnline.WebApi.Features.Sessao.GetSessaoById;
using PsicoOnline.WebApi.Features.Sessao.GetSessoesByPacienteIdData;
using PsicoOnline.WebApi.Features.Sessao.UpdateSessao;

namespace PsicoOnline.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SessaoController(ISender sender) : ControllerBase
{
	private readonly IAppLogger<SessaoController> _appLogger = new AppLogger<SessaoController>();

	[HttpGet]
	[Route("GetAll")]
	[EnableQuery]
	public async Task<ActionResult> GetAllSessoesAsync()
	{
		var sessoes = await sender.Send(new GetAllSessoesQuery());

		return sessoes == null || !sessoes.Any()
			? NotFound("Não há sessões cadastradas.")
			: Ok(sessoes);
	}

	[HttpGet]
	[Route("GetById/{id}")]
	public async Task<ActionResult> GetSessaoByIdAsync(int id)
	{
		var sessao = await sender.Send(new GetSessaoByIdQuery(id));

		return sessao == null
			? NotFound($"Não há sessão cadastrada com o id {id}.")
			: Ok(sessao);
	}

	[HttpGet]
	[Route("GetByPacienteIdData")]
	public async Task<ActionResult> GetSessoesByPacienteIdDataAsync(GetSessoesByPacienteIdDataQuery getSessoesByPacienteIdDataQuery)
	{
		var sessoes = await sender.Send(getSessoesByPacienteIdDataQuery);

		return sessoes == null || !sessoes.Any()
			? NotFound("Não há sessões cadastradas para os parâmetros informados.")
			: Ok(sessoes);
	}

	[HttpPost]
	[Route("Add")]
	public async Task<ActionResult> AddSessaoAsync(AddSessaoCommand addSessaoCommand)
	{
		var sessao = await sender.Send(addSessaoCommand);

		return Ok(sessao);
	}

	[HttpDelete]
	[Route("Delete/{id}")]
	public async Task<ActionResult> DeleteSessaoAsync(int id)
	{
		try
		{
			var retorno = await sender.Send(new DeleteSessaoCommand(id));

			return Ok(retorno);
		}
		catch (Exception ex)
		{
			return BadRequest(ex.Message);
		}
	}

	[HttpPut]
	[Route("Update")]
	public async Task<ActionResult> UpdateSessaoAsync(UpdateSessaoCommand updateSessaoCommand)
	{
		try
		{
			var retorno = await sender.Send(updateSessaoCommand);

			return Ok(retorno);
		}
		catch (Exception ex)
		{
			return BadRequest(ex.Message);
		}
	}
}