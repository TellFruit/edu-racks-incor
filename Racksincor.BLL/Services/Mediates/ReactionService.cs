using Racksincor.BLL.DTO;
using Racksincor.BLL.DTO.Queries;
using Racksincor.BLL.Interfaces;

namespace Racksincor.BLL.Services.Mediates
{
    public class ReactionService : IMediateService<ReactionDTO, ReactionQuery>
    {
        private readonly IRepository<ReactionDTO, ReactionQuery> _reactionRepository;

        public ReactionService(IRepository<ReactionDTO, ReactionQuery> reactionRepository)
        {
            _reactionRepository = reactionRepository;
        }

        public async Task<ReactionDTO> Create(ReactionDTO entry)
        {
            return await _reactionRepository.Create(entry);
        }

        public async Task<IReadOnlyList<ReactionDTO>> ReadWithQuery(ReactionQuery? query)
        {
            return await _reactionRepository.ReadWithQuery(query);
        }

        public async Task<ReactionDTO> Update(ReactionDTO entry)
        {
            return await _reactionRepository.Update(entry);
        }

        public async Task Delete(ReactionDTO entry)
        {
            var reaction = await _reactionRepository.ReadWithQuery(new ReactionQuery { Id = entry.Id });

            await _reactionRepository.Delete(new ReactionDTO { Id = entry.Id });
        }
    }
}
