using Microsoft.AspNetCore.Mvc;
using PsicoOnline.Core.DTO;
using PsicoOnline.Core.Interfaces;
using PsicoOnline.Infrastructure.Logging;

namespace PsicoOnline.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        private readonly IPacienteRepository _pacienteRepository;
        private readonly IAppLogger<PacienteController> _appLogger;

        public PacienteController(IPacienteRepository pacienteRepository)
        {
            _pacienteRepository = pacienteRepository;
            _appLogger = new AppLogger<PacienteController>();
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult> GetAllPacientesAsync()
        {
            var pacientes = await _pacienteRepository.GetAllPacientesAsync();

            if (pacientes == null)
            {
                return NotFound("Não há pacientes cadastrados.");
            }

            return Ok(pacientes);
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<ActionResult> GetPacienteByIdAsync(int id)
        {
            var paciente = await _pacienteRepository.GetPacienteByIdAsync(id);

            if (paciente == null)
            {
                return NotFound($"Não há paciente cadastrado com o id {id}.");
            }

            return Ok(paciente);
        }

        [HttpPost]
        [Route("Add")]
        public async Task<ActionResult> AddPacienteAsync(PacienteAddDTO pacienteDTO)
        {
            var paciente = await _pacienteRepository.AddPacienteAsync(pacienteDTO);

            return Ok(paciente);
        }

        [HttpDelete]
        [Route("DeleteAll")]
        public async Task<ActionResult> DeleteAllPacientesAsync()
        {
            await _pacienteRepository.DeleteAllPacientesAsync();

            return Ok("Todos os pacientes foram excluídos com sucesso.");
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<ActionResult> DeletePacienteAsync(int id)
        {
            try
            {
                await _pacienteRepository.DeletePacienteAsync(id);

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
                await _pacienteRepository.UpdatePacienteAsync(pacienteDTO);

                return Ok("Paciente atualizado com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}