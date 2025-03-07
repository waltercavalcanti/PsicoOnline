using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using PsicoOnline.Core.Interfaces;
using PsicoOnline.Infrastructure.Logging;
using PsicoOnline.WebApi.Features.Paciente.AddPaciente;
using PsicoOnline.WebApi.Features.Paciente.DeletePaciente;
using PsicoOnline.WebApi.Features.Paciente.GetAllPacientes;
using PsicoOnline.WebApi.Features.Paciente.GetPacienteById;
using PsicoOnline.WebApi.Features.Paciente.UpdatePaciente;

namespace PsicoOnline.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PacienteController(ISender sender) : ControllerBase
{
	private readonly IAppLogger<PacienteController> _appLogger = new AppLogger<PacienteController>();

	[HttpGet]
	[Route("GetAll")]
	[EnableQuery]
	public async Task<ActionResult> GetAllPacientesAsync()
	{
		var pacientes = await sender.Send(new GetAllPacientesQuery());

		return pacientes == null || !pacientes.Any()
			? NotFound("Não há pacientes cadastrados.")
			: Ok(pacientes);
	}

	[HttpGet]
	[Route("GetById/{id}")]
	public async Task<ActionResult> GetPacienteByIdAsync(int id)
	{
		var paciente = await sender.Send(new GetPacienteByIdQuery(id));

		return paciente == null
			? NotFound($"Não há paciente cadastrado com o id {id}.")
			: Ok(paciente);
	}

	[HttpPost]
	[Route("Add")]
	public async Task<ActionResult> AddPacienteAsync(AddPacienteCommand addPacienteCommand)
	{
		var paciente = await sender.Send(addPacienteCommand);

		return Ok(paciente);
	}

	[HttpDelete]
	[Route("Delete/{id}")]
	public async Task<ActionResult> DeletePacienteAsync(int id)
	{
		try
		{
			var retorno = await sender.Send(new DeletePacienteCommand(id));

			return Ok(retorno);
		}
		catch (Exception ex)
		{
			return BadRequest(ex.Message);
		}
	}

	[HttpPut]
	[Route("Update")]
	public async Task<ActionResult> UpdatePacienteAsync(UpdatePacienteCommand updatePacienteCommand)
	{
		try
		{
			var retorno = await sender.Send(updatePacienteCommand);

			return Ok(retorno);
		}
		catch (Exception ex)
		{
			return BadRequest(ex.Message);
		}
	}
}