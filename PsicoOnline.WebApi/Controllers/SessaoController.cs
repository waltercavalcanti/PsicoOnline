using Microsoft.AspNetCore.Mvc;
using PsicoOnline.Core.DTO;
using PsicoOnline.Core.Interfaces;
using PsicoOnline.Infrastructure.Logging;

namespace PsicoOnline.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SessaoController : ControllerBase
{
    private readonly ISessaoRepository _sessaoRepository;
    private readonly IAppLogger<SessaoController> _appLogger;

    public SessaoController(ISessaoRepository sessaoRepository)
    {
        _sessaoRepository = sessaoRepository;
        _appLogger = new AppLogger<SessaoController>();
    }

    [HttpGet]
    [Route("GetAll")]
    public async Task<ActionResult> GetAllSessoesAsync()
    {
        var sessoes = await _sessaoRepository.GetAllSessoesAsync();

        if (sessoes == null || sessoes.Count == 0)
        {
            return NotFound("Não há sessões cadastradas.");
        }

        return Ok(sessoes);
    }

    [HttpGet]
    [Route("GetById/{id}")]
    public async Task<ActionResult> GetSessaoByIdAsync(int id)
    {
        var sessao = await _sessaoRepository.GetSessaoByIdAsync(id);

        if (sessao == null)
        {
            return NotFound($"Não há sessão cadastrada com o id {id}.");
        }

        return Ok(sessao);
    }

    [HttpGet]
    [Route("GetByPacienteIdData")]
    public async Task<ActionResult> GetSessoesByPacienteIdDataAsync(SessaoFilterDTO sessaoDTO)
    {
        var sessoes = await _sessaoRepository.GetSessoesByPacienteIdDataAsync(sessaoDTO);

        if (sessoes == null || sessoes.Count == 0)
        {
            return NotFound("Não há sessões cadastradas para os parâmetros informados.");
        }

        return Ok(sessoes);
    }

    [HttpPost]
    [Route("Add")]
    public async Task<ActionResult> AddSessaoAsync(SessaoAddDTO sessaoDTO)
    {
        var sessao = await _sessaoRepository.AddSessaoAsync(sessaoDTO);

        return Ok(sessao);
    }

    [HttpDelete]
    [Route("DeleteAll")]
    public async Task<ActionResult> DeleteAllSessoesAsync()
    {
        await _sessaoRepository.DeleteAllSessoesAsync();

        return Ok("Todos as sessões foram excluídas com sucesso.");
    }

    [HttpDelete]
    [Route("Delete/{id}")]
    public async Task<ActionResult> DeleteSessaoAsync(int id)
    {
        try
        {
            await _sessaoRepository.DeleteSessaoAsync(id);

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
            await _sessaoRepository.UpdateSessaoAsync(sessaoDTO);

            return Ok("Sessão atualizada com sucesso.");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}