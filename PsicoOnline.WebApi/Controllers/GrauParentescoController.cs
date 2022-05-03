using Microsoft.AspNetCore.Mvc;
using PsicoOnline.Core.DTO;
using PsicoOnline.Core.Interfaces;
using PsicoOnline.Infrastructure.Logging;

namespace PsicoOnline.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GrauParentescoController : ControllerBase
    {
        private readonly IGrauParentescoRepository _grauParentescoRepository;
        private readonly IAppLogger<GrauParentescoController> _appLogger;

        public GrauParentescoController(IGrauParentescoRepository grauParentescoRepository)
        {
            _grauParentescoRepository = grauParentescoRepository;
            _appLogger = new AppLogger<GrauParentescoController>();
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult> GetAllGrausParentescoAsync()
        {
            var grausParentesco = await _grauParentescoRepository.GetAllGrausParentescoAsync();

            return Ok(grausParentesco);
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<ActionResult> GetGrauParentescoByIdAsync(int id)
        {
            var grauParentesco = await _grauParentescoRepository.GetGrauParentescoByIdAsync(id);

            return Ok(grauParentesco);
        }

        [HttpPost]
        [Route("Add")]
        public async Task<ActionResult> AddGrauParentescoAsync(GrauParentescoDTO grauParentescoDTO)
        {
            var grauParentesco = await _grauParentescoRepository.AddGrauParentescoAsync(grauParentescoDTO);

            return Ok(grauParentesco);
        }

        [HttpDelete]
        [Route("DeleteAll")]
        public async Task<ActionResult> DeleteAllGrausParentescoAsync()
        {
            await _grauParentescoRepository.DeleteAllGrausParentescoAsync();

            return Ok("Todos os graus de parentesco foram deletados com sucesso.");
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<ActionResult> DeleteGrauParentescoAsync(int id)
        {
            try
            {
                await _grauParentescoRepository.DeleteGrauParentescoAsync(id);

                return Ok("Grau de parentesco deletado com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("Update")]
        public async Task<ActionResult> UpdateGrauParentescoAsync(GrauParentescoDTO grauParentescoDTO)
        {
            try
            {
                await _grauParentescoRepository.UpdateGrauParentescoAsync(grauParentescoDTO);

                return Ok("Grau de parentesco atualizado com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}