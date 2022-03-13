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
        public async Task<ActionResult> GetAllPacientes()
        {
            var pacientes = await _pacienteRepository.GetAllPacientes();

            return Ok(pacientes);
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<ActionResult> GetPacienteById(int id)
        {
            var paciente = await _pacienteRepository.GetPacienteById(id);

            return Ok(paciente);
        }

        [HttpPost]
        [Route("Add")]
        public async Task<ActionResult> AddPaciente(PacienteDTO pacienteDTO)
        {
            var paciente = await _pacienteRepository.AddPaciente(pacienteDTO);

            return Ok(paciente);
        }

        [HttpDelete]
        [Route("DeleteAll")]
        public async Task<ActionResult> DeleteAllPacientes()
        {
            await _pacienteRepository.DeleteAllPacientes();

            return Ok("Todos os pacientes foram deletados com sucesso.");
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<ActionResult> DeletePaciente(int id)
        {
            try
            {
                await _pacienteRepository.DeletePaciente(id);

                return Ok("Paciente deletado com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("Update")]
        public async Task<ActionResult> UpdatePaciente(PacienteDTO pacienteDTO)
        {
            try
            {
                await _pacienteRepository.UpdatePaciente(pacienteDTO);

                return Ok("Paciente atualizado com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}