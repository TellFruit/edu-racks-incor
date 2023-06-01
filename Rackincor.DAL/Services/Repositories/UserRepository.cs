using Racksincor.BLL.DTO.Queries;
using Racksincor.BLL.DTO.User;
using Racksincor.BLL.Interfaces;
using Racksincor.DAL.Services.Repositories.Abstract;
using System.Data;

namespace Racksincor.DAL.Services.Repositories
{
    internal class UserRepository : BaseRepository, IRepository<UserDTO, UserQuery>
    {
        public UserRepository(IDbConnection connection) : base(connection)
        {
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
