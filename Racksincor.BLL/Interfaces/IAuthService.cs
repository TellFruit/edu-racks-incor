using Racksincor.BLL.DTO.User;

namespace Racksincor.BLL.Interfaces
{
    public interface IAuthService
    {
        public Task<string> Login(UserDTO user);

        public Task Register(RegisterDTO user);
    }
}
