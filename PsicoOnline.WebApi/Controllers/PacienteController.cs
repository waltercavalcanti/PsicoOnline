using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using PsicoOnline.Core.DTO;
using PsicoOnline.Core.Interfaces;
using PsicoOnline.Infrastructure.Logging;

namespace PsicoOnline.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PacienteController(IPacienteRepository pacienteRepository) : ControllerBase
{
	private readonly IAppLogger<PacienteController> _appLogger = new AppLogger<PacienteController>();

	[HttpGet]
	[Route("GetAll")]
	[EnableQuery]
	public async Task<ActionResult> GetAllPacientesAsync()
	{
		var pacientes = await pacienteRepository.GetAllPacientesAsync();

		return pacientes == null || !pacientes.Any()
			? NotFound("Não há pacientes cadastrados.")
			: Ok(pacientes);
	}

	[HttpGet]
	[Route("GetById/{id}")]
	public async Task<ActionResult> GetPacienteByIdAsync(int id)
	{
		var paciente = await pacienteRepository.GetPacienteByIdAsync(id);

		return paciente == null
			? NotFound($"Não há paciente cadastrado com o id {id}.")
			: Ok(paciente);
	}

	[HttpPost]
	[Route("Add")]
	public async Task<ActionResult> AddPacienteAsync(PacienteAddDTO pacienteDTO)
	{
		var paciente = await pacienteRepository.AddPacienteAsync(pacienteDTO);

		return Ok(paciente);
	}

	[HttpDelete]
	[Route("Delete/{id}")]
	public async Task<ActionResult> DeletePacienteAsync(int id)
	{
		try
		{
			await pacienteRepository.DeletePacienteAsync(id);

			return Ok("Paciente excluído com sucesso.");
		}
		catch (Exception ex)
		{
			return BadRequest(ex.Message);
		}
	}

	[HttpPut]
	[Route("Update")]
	public async Task<ActionResult> UpdatePacienteAsync(PacienteUpdateDTO pacienteDTO)
	{
		try
		{
			await pacienteRepository.UpdatePacienteAsync(pacienteDTO);

			return Ok("Paciente atualizado com sucesso.");
		}
		catch (Exception ex)
		{
			return BadRequest(ex.Message);
		}
	}
}