using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Racksincor.BLL.DTO.User;
using Racksincor.BLL.Interfaces;

namespace Racksincor.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private IUserMediateService _authService;

        public AuthController(IUserMediateService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        [Route(nameof(Login))]
        public async Task<IActionResult> Login(LoginDTO user)
        {
            try
            {
                return Ok(await _authService.Login(user));
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

        [HttpPost]
        [Route(nameof(Register))]
        [JwtAuthorize(Roles = "Admin")]
        public async Task<IActionResult> Register(RegisterDTO user)
        {
            try
            {
                return Ok(await _authService.Register(user));
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
    }
}
 