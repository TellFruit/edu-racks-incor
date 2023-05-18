using Racksincor.BLL.DTO.User;
using Racksincor.BLL.Interfaces;

namespace Racksincor.BLL.Services.Mediates
{
    public class AuthService : IAuthService
    {
        public Task<string> Login(UserDTO user)
        {
            throw new NotImplementedException();
        }

        public Task Register(RegisterDTO user)
        {
            throw new NotImplementedException();
        }
    }
}
