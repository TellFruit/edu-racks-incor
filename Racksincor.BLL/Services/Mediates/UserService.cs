using Racksincor.BLL.DTO.Queries;
using Racksincor.BLL.DTO.User;
using Racksincor.BLL.Interfaces;

namespace Racksincor.BLL.Services.Mediates
{
    public class UserService : IMediateService<UserDTO, UserQuery>
    {
        private readonly IRepository<UserDTO, UserQuery> _repository;

        public UserService(IRepository<UserDTO, UserQuery> repository)
        {
            _repository = repository;
        }

        public Task<UserDTO> Create(UserDTO entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(UserDTO entity)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<UserDTO>> ReadWithQuery(UserQuery? obj)
        {
            throw new NotImplementedException();
        }

        public Task<UserDTO> Update(UserDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
