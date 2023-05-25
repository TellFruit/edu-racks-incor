using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Racksincor.BLL.DTO;
using Racksincor.BLL.DTO.Queries;
using Racksincor.BLL.Interfaces;

namespace Racksincor.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [JwtAuthorize(Roles = "Admin")]
    public class CompanyController : ControllerBase
    {
        private readonly IMediateService<CompanyDTO, CompanyQuery> _companyService;

        public CompanyController(IMediateService<CompanyDTO, CompanyQuery> companyService)
        {
            _companyService = companyService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CompanyDTO company)
        {
            try
            {
                var createdCompany = await _companyService.Create(company);

                return Ok(createdCompany);
            }
            catch (ValidationException ex)
            {
                ex.AddToModelState(ModelState);

                return BadRequest(ModelState);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var companies = await _companyService.ReadWithQuery(default);

                return Ok(companies);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var companyQuery = new CompanyQuery { Id = id };
                
                var company = await _companyService.ReadWithQuery(companyQuery);

                if (company.Any())
                {
                    return Ok(company);
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

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CompanyDTO company)
        {
            try
            {
                company.Id = id;
                var updatedCompany = await _companyService.Update(company);
                if (updatedCompany != null)
                {
                    return Ok(updatedCompany);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (ValidationException ex)
            {
                ex.AddToModelState(ModelState);

                return BadRequest(ModelState);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _companyService.Delete(new CompanyDTO { Id = id });

                return NoContent();
            }
            // TODO: lacks validation exception handler
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
