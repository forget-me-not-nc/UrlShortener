using BusinessLogicLayer.DTOs.UrlDTOs;
using BusinessLogicLayer.DTOs.UserDTOs;
using BusinessLogicLayer.Services.UrlServices;
using BusinessLogicLayer.Services.UserServices;
using BusinessLogicLayer.Services.UserServices.Impls;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UrlShortener.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Authorize(Roles ="ADMIN")]
        public async Task<ActionResult<IEnumerable<UserResponse>>> GetAll()
        {
            try
            {
                return Ok(await _userService.GetAllAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        //[Authorize(Roles = "ADMIN")]
        public async Task<ActionResult<UserResponse>> Create([FromBody] UserCreateRequest body)
        {
            try
            {
                if (body == null) throw new ArgumentNullException("Empty body!");

                if (!ModelState.IsValid) throw new InvalidOperationException("Invalid body!");

                return Ok(await _userService.CreateAsync(body));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Authorize(Roles = "USER")]
        public async Task<ActionResult<UserResponse>> Update([FromBody] UserUpdateRequest body)
        {
            try
            {
                if (body == null) throw new ArgumentNullException("Empty body!");

                if (!ModelState.IsValid) throw new InvalidOperationException("Invalid body!");

                return Ok(await _userService.UpdateAsync(body));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "USER")]
        public async Task<ActionResult<UserResponse>> GetById(int id)
        {
            try
            {
                return Ok(await _userService.GetAsync(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        //[Authorize(Roles = "USER")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _userService.DeleteAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
