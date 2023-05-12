using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Racksincor.BLL.DTO;
using Racksincor.BLL.DTO.Queries;
using Racksincor.BLL.Interfaces;

namespace Racksincor.Controllers
{
    [Authorize(Roles = "Admin")]
    [ApiController]
    [Route("api/[controller]")]
    public class CompanyController : ControllerBase
    {
        private readonly IRepository<CompanyDTO, CompanyQuery> _companyRepository;

        public CompanyController(IRepository<CompanyDTO, CompanyQuery> companyRepository)
        {
            _companyRepository = companyRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CompanyDTO companyDTO)
        {
            var createdCompany = await _companyRepository.Create(companyDTO);
            return Ok(createdCompany);
        }

        [HttpGet]
        public async Task<IActionResult> Read()
        {
            var companies = await _companyRepository.Read();
            return Ok(companies);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Read(int id)
        {
            var companyQuery = new CompanyQuery { Id = id };
            var companies = await _companyRepository.ReadWithQuery(companyQuery);
            return Ok(companies);
        }

        [HttpPut]
        public async Task<IActionResult> Update(CompanyDTO companyDTO)
        {
            var updatedCompany = await _companyRepository.Update(companyDTO);
            return Ok(updatedCompany);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var companyDTO = new CompanyDTO { Id = id };
            await _companyRepository.Delete(companyDTO);
            return NoContent();
        }
    }
}
