using Microsoft.AspNetCore.Mvc;
using Racksincor.BLL.DTO.Queries;
using Racksincor.BLL.Interfaces;

namespace Racksincor.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [JwtAuthorize(Roles = "Admin")]
    public class EmployeeController : ControllerBase
    {
        private readonly IUserMediateService _userService;

        public EmployeeController(IUserMediateService userService)
        {
            _userService = userService;
        }

        [HttpGet("shop/{id}")]
        public async Task<IActionResult> GetByShopId(int id)
        {
            try
            {
                var promotionQuery = new UserQuery { ShopId = id };

                var employees = await _userService.ReadWithQuery(promotionQuery);

                if (employees.Any())
                {
                    return Ok(employees);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
