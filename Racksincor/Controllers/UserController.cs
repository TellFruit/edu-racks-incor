using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Racksincor.BLL.DTO.User;
using Racksincor.BLL.Interfaces;

namespace Racksincor.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [JwtAuthorize(Roles = "Admin")]
    public class UserController : ControllerBase
    {
        private readonly IUserMediateService _userService;

        public UserController(IUserMediateService userService)
        {
            _userService = userService;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, RegisterDTO user)
        {
            try
            {
                user.Id = id;

                await _userService.Update(user);

                return Ok();
            }
            catch (ValidationException ex)
            {
                ex.AddToModelState(ModelState);

                return BadRequest(ModelState);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                await _userService.Delete(new UserDTO { Id = id });

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
