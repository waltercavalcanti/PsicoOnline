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

            return Ok(pacientes);
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<ActionResult> GetPacienteByIdAsync(int id)
        {
            var paciente = await _pacienteRepository.GetPacienteByIdAsync(id);

            return Ok(paciente);
        }

        [HttpPost]
        [Route("Add")]
        public async Task<ActionResult> AddPacienteAsync(PacienteDTO pacienteDTO)
        {
            var paciente = await _pacienteRepository.AddPacienteAsync(pacienteDTO);

            return Ok(paciente);
        }

        [HttpDelete]
        [Route("DeleteAll")]
        public async Task<ActionResult> DeleteAllPacientesAsync()
        {
            await _pacienteRepository.DeleteAllPacientesAsync();

            return Ok("Todos os pacientes foram deletados com sucesso.");
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<ActionResult> DeletePacienteAsync(int id)
        {
            try
            {
                await _pacienteRepository.DeletePacienteAsync(id);

                return Ok("Paciente deletado com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("Update")]
        public async Task<ActionResult> UpdatePacienteAsync(PacienteDTO pacienteDTO)
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