using BusinessLogicLayer.DTOs.AliasDTOs;
using BusinessLogicLayer.DTOs.UrlDTOs;
using BusinessLogicLayer.Services.AliasServices;
using BusinessLogicLayer.Services.UrlServices;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UrlShortener.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AliasController: ControllerBase
    {
        private readonly IAliasService _alissService;
        public AliasController(IAliasService alissService)
        {
            _alissService = alissService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AliasResponse>>> GetAll()
        {
            try
            {
                return Ok(await _alissService.GetAllAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "ADMIN")]
        public async Task<ActionResult<AliasResponse>> GetById(int id)
        {
            try
            {
                return Ok(await _alissService.GetAsync(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        [Authorize(Roles = "ADMIN")]
        public async Task<ActionResult<AliasResponse>> Create([FromBody] AliasCreateRequest body)
        {
            try
            {
                if (body == null) throw new ArgumentNullException("Empty body!");

                if (!ModelState.IsValid) throw new InvalidOperationException("Invalid body!");

                return Ok(await _alissService.CreateAsync(body));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Authorize(Roles = "ADMIN")]
        public async Task<ActionResult<AliasResponse>> Update([FromBody] AliasUpdateRequest body)
        {
            try
            {
                if (body == null) throw new ArgumentNullException("Empty body!");

                if (!ModelState.IsValid) throw new InvalidOperationException("Invalid body!");

                return Ok(await _alissService.UpdateAsync(body));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "ADMIN")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _alissService.DeleteAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
