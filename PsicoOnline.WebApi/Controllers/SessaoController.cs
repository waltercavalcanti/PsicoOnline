using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using PsicoOnline.Core.DTO;
using PsicoOnline.Core.Interfaces;
using PsicoOnline.Infrastructure.Logging;

namespace PsicoOnline.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SessaoController(ISessaoRepository sessaoRepository) : ControllerBase
{
	private readonly IAppLogger<SessaoController> _appLogger = new AppLogger<SessaoController>();

	[HttpGet]
	[Route("GetAll")]
	[EnableQuery]
	public async Task<ActionResult> GetAllSessoesAsync()
	{
		var sessoes = await sessaoRepository.GetAllSessoesAsync();

		return sessoes == null || !sessoes.Any()
			? NotFound("Não há sessões cadastradas.")
			: Ok(sessoes);
	}

	[HttpGet]
	[Route("GetById/{id}")]
	public async Task<ActionResult> GetSessaoByIdAsync(int id)
	{
		var sessao = await sessaoRepository.GetSessaoByIdAsync(id);

		return sessao == null
			? NotFound($"Não há sessão cadastrada com o id {id}.")
			: Ok(sessao);
	}

	[HttpGet]
	[Route("GetByPacienteIdData")]
	public async Task<ActionResult> GetSessoesByPacienteIdDataAsync(SessaoFilterDTO sessaoDTO)
	{
		var sessoes = await sessaoRepository.GetSessoesByPacienteIdDataAsync(sessaoDTO);

		return sessoes == null || !sessoes.Any()
			? NotFound("Não há sessões cadastradas para os parâmetros informados.")
			: Ok(sessoes);
	}

	[HttpPost]
	[Route("Add")]
	public async Task<ActionResult> AddSessaoAsync(SessaoAddDTO sessaoDTO)
	{
		var sessao = await sessaoRepository.AddSessaoAsync(sessaoDTO);

		return Ok(sessao);
	}

	[HttpDelete]
	[Route("Delete/{id}")]
	public async Task<ActionResult> DeleteSessaoAsync(int id)
	{
		try
		{
			await sessaoRepository.DeleteSessaoAsync(id);

			return Ok("Sessão excluída com sucesso.");
		}
		catch (Exception ex)
		{
			return BadRequest(ex.Message);
		}
	}

	[HttpPut]
	[Route("Update")]
	public async Task<ActionResult> UpdateSessaoAsync(SessaoUpdateDTO sessaoDTO)
	{
		try
		{
			await sessaoRepository.UpdateSessaoAsync(sessaoDTO);

			return Ok("Sessão atualizada com sucesso.");
		}
		catch (Exception ex)
		{
			return BadRequest(ex.Message);
		}
	}
}