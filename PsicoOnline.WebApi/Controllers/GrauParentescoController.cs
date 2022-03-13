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
        public async Task<ActionResult> GetAllGrausParentesco()
        {
            var grausParentesco = await _grauParentescoRepository.GetAllGrausParentesco();

            return Ok(grausParentesco);
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<ActionResult> GetGrauParentescoById(int id)
        {
            var grauParentesco = await _grauParentescoRepository.GetGrauParentescoById(id);

            return Ok(grauParentesco);
        }

        [HttpPost]
        [Route("Add")]
        public async Task<ActionResult> AddGrauParentesco(GrauParentescoDTO grauParentescoDTO)
        {
            var grauParentesco = await _grauParentescoRepository.AddGrauParentesco(grauParentescoDTO);

            return Ok(grauParentesco);
        }

        [HttpDelete]
        [Route("DeleteAll")]
        public async Task<ActionResult> DeleteAllGrausParentesco()
        {
            await _grauParentescoRepository.DeleteAllGrausParentesco();

            return Ok("Todos os graus de parentesco foram deletados com sucesso.");
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<ActionResult> DeleteGrauParentesco(int id)
        {
            try
            {
                await _grauParentescoRepository.DeleteGrauParentesco(id);

                return Ok("Grau de parentesco deletado com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("Update")]
        public async Task<ActionResult> UpdateGrauParentesco(GrauParentescoDTO grauParentescoDTO)
        {
            try
            {
                await _grauParentescoRepository.UpdateGrauParentesco(grauParentescoDTO);

                return Ok("Grau de parentesco atualizado com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}