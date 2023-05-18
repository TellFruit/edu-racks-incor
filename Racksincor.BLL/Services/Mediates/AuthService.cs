using Racksincor.BLL.DTO.User;
using Racksincor.BLL.Interfaces;

namespace Racksincor.BLL.Services.Mediates
{
    public class AuthService : IAuthService
    {
        public Task<string> Login(string email, string password)
        {
            throw new NotImplementedException();
        }

        public Task Register(string email, string password)
        {
            throw new NotImplementedException();
        }
    }
}
