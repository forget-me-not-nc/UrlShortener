using BusinessLogicLayer.DTOs.UrlDTOs;
using BusinessLogicLayer.Services.UrlServices;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UrlShortener.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UrlController: ControllerBase
    {
        private readonly IUrlService _urlService;
        public UrlController(IUrlService urlService)
        {
            _urlService = urlService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UrlResponse>>> GetAll()
        {
            try
            {
                return Ok(await _urlService.GetAllAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("user/{id}")]
        [Authorize(Roles = "USER")]
        public async Task<ActionResult<IEnumerable<UrlResponse>>> GetAllByUserId(int id)
        {
            try
            {
                return Ok(await _urlService.GetUrlsByUserId(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "USER")]
        public async Task<ActionResult<UrlResponse>> GetById(int id)
        {
            try
            {
                return Ok(await _urlService.GetAsync(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        [Authorize(Roles = "USER")]
        public async Task<ActionResult<UrlResponse>> Create([FromBody] UrlCreateRequest body)
        {
            try
            {
                if (body == null) throw new ArgumentNullException("Empty body!");

                if (!ModelState.IsValid) throw new InvalidOperationException("Invalid body!");

                return Ok(await _urlService.CreateAsync(body));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Authorize(Roles = "USER")]
        public async Task<ActionResult<UrlResponse>> Update( [FromBody] UrlUpdateRequest body)
        {
            try
            {
                if (body == null) throw new ArgumentNullException("Empty body!");

                if (!ModelState.IsValid) throw new InvalidOperationException("Invalid body!");

                return Ok(await _urlService.UpdateAsync(body));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "USER")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _urlService.DeleteAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
