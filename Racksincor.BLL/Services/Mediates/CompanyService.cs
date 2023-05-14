using Racksincor.BLL.DTO;
using Racksincor.BLL.DTO.Queries;
using Racksincor.BLL.Interfaces;

namespace Racksincor.BLL.Services.Mediates
{
    public class CompanyService : IMediateService<CompanyDTO, CompanyQuery>
    {
        private readonly IRepository<CompanyDTO, CompanyQuery> _companyRepository;

        public CompanyService(IRepository<CompanyDTO, CompanyQuery> companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task<CompanyDTO> Create(CompanyDTO entry)
        {
            // Perform any additional business logic or validation here

            return await _companyRepository.Create(entry);
        }

        public async Task<IReadOnlyList<CompanyDTO>> ReadWithQuery(CompanyQuery? query)
        {
            // Perform any additional business logic or validation here

            return await _companyRepository.ReadWithQuery(query);
        }

        public async Task<CompanyDTO> Update(CompanyDTO entry)
        {
            // Perform any additional business logic or validation here

            return await _companyRepository.Update(entry);
        }

        public async Task Delete(CompanyDTO entry)
        {
            // Perform any additional business logic or validation here

            await _companyRepository.Delete(new CompanyDTO { Id = entry.Id });
        }
    }
}
