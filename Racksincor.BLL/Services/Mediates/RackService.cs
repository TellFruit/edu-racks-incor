using Racksincor.BLL.DTO;
using Racksincor.BLL.DTO.Queries;
using Racksincor.BLL.Interfaces;

namespace Racksincor.BLL.Services.Mediates
{
    public class RackService : IMediateService<RackDTO, RackQuery>
    {
        private readonly IRepository<RackDTO, RackQuery> _rackRepository;

        public RackService(IRepository<RackDTO, RackQuery> rackRepository)
        {
            _rackRepository = rackRepository;
        }

        public async Task<RackDTO> Create(RackDTO entry)
        {
            return await _rackRepository.Create(entry);
        }

        public async Task<IReadOnlyList<RackDTO>> ReadWithQuery(RackQuery? query)
        {
            return await _rackRepository.ReadWithQuery(query);
        }

        public async Task<RackDTO> Update(RackDTO entry)
        {
            return await _rackRepository.Update(entry);
        }

        public async Task Delete(RackDTO entry)
        {
            var rack = await _rackRepository.ReadWithQuery(new RackQuery { Id = entry.Id });

            await _rackRepository.Delete(new RackDTO { Id = entry.Id });
        }
    }
}
