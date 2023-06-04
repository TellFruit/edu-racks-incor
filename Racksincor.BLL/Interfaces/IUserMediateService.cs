using Racksincor.BLL.DTO.Queries;
using Racksincor.BLL.DTO.User;

namespace Racksincor.BLL.Interfaces
{
    public interface IUserMediateService
    {
        Task<string> Login(UserDTO user);

        Task<IReadOnlyList<UserDTO>> ReadWithQuery(UserQuery query); 

        Task<UserDTO> Register(RegisterDTO user);

        Task<UserDTO> Update(UserUpdateDTO user);

        Task Delete(UserDTO user);
    }
}
