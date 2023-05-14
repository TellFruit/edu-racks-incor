using FluentValidation;
using Racksincor.BLL.DTO;
using Racksincor.BLL.DTO.Queries;
using Racksincor.BLL.Interfaces;

namespace Racksincor.BLL.Services.Mediates
{
    public class CompanyService : IMediateService<CompanyDTO, CompanyQuery>
    {
        private readonly IRepository<CompanyDTO, CompanyQuery> _companyRepository;
        private readonly IValidator<CompanyDTO> _companyValidator;

        public CompanyService(IRepository<CompanyDTO, CompanyQuery> companyRepository, IValidator<CompanyDTO> companyValidator)
        {
            _companyRepository = companyRepository;
            _companyValidator = companyValidator;
        }

        public async Task<CompanyDTO> Create(CompanyDTO entry)
        {
            await _companyValidator.ValidateAndThrowAsync(entry);

            return await _companyRepository.Create(entry);
        }

        public async Task<IReadOnlyList<CompanyDTO>> ReadWithQuery(CompanyQuery? query)
        {
            return await _companyRepository.ReadWithQuery(query);
        }

        public async Task<CompanyDTO> Update(CompanyDTO entry)
        {
            await _companyValidator.ValidateAndThrowAsync(entry);

            return await _companyRepository.Update(entry);
        }

        public async Task Delete(CompanyDTO entry)
        {
            var company = await _companyRepository.ReadWithQuery(new CompanyQuery { Id = entry.Id });

            // this may not work as expected
            await _companyValidator.ValidateAndThrowAsync(company.First());

            await _companyRepository.Delete(new CompanyDTO { Id = entry.Id });
        }
    }
}
