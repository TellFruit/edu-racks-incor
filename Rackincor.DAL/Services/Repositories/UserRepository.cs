using Racksincor.BLL.DTO.User;
using Racksincor.BLL.Interfaces;
using Racksincor.DAL.Services.Repositories.Abstract;

namespace Racksincor.DAL.Services.Repositories
{
    internal class UserRepository : BaseRepository, IRepository<UserDTO, UserQuery>
    {
    }
}
