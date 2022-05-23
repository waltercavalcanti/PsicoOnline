using Microsoft.AspNetCore.Mvc;
using PsicoOnline.Core.DTO;
using PsicoOnline.Core.Interfaces;
using PsicoOnline.Infrastructure.Logging;

namespace PsicoOnline.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResponsavelController : ControllerBase
    {
        private readonly IResponsavelRepository _responsavelRepository;
        private readonly IAppLogger<ResponsavelController> _appLogger;

        public ResponsavelController(IResponsavelRepository responsavelRepository)
        {
            _responsavelRepository = responsavelRepository;
            _appLogger = new AppLogger<ResponsavelController>();
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult> GetAllResponsaveisAsync()
        {
            var responsaveis = await _responsavelRepository.GetAllResponsaveisAsync();

            if (responsaveis == null)
            {
                return NotFound("Não há responsáveis cadastrados.");
            }

            return Ok(responsaveis);
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<ActionResult> GetResponsavelByIdAsync(int id)
        {
            var responsavel = await _responsavelRepository.GetResponsavelByIdAsync(id);

            if (responsavel == null)
            {
                return NotFound($"Não há responsável cadastrado com o id {id}.");
            }

            return Ok(responsavel);
        }

        [HttpPost]
        [Route("Add")]
        public async Task<ActionResult> AddResponsavelAsync(ResponsavelAddDTO responsavelDTO)
        {
            var responsavel = await _responsavelRepository.AddResponsavelAsync(responsavelDTO);

            return Ok(responsavel);
        }

        [HttpDelete]
        [Route("DeleteAll")]
        public async Task<ActionResult> DeleteAllResponsaveisAsync()
        {
            await _responsavelRepository.DeleteAllResponsaveisAsync();

            return Ok("Todos os responsáveis foram excluídos com sucesso.");
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<ActionResult> DeleteResponsavelAsync(int id)
        {
            try
            {
                await _responsavelRepository.DeleteResponsavelAsync(id);

                return Ok("Responsável excluído com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("Update")]
        public async Task<ActionResult> UpdateResponsavelAsync(ResponsavelUpdateDTO responsavelDTO)
        {
            try
            {
                await _responsavelRepository.UpdateResponsavelAsync(responsavelDTO);

                return Ok("Responsável atualizado com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}