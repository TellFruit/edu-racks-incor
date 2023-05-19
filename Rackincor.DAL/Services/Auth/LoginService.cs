using Microsoft.AspNetCore.Identity;
using Racksincor.BLL.Interfaces.Outer;
using Racksincor.DAL.Interfaces;
using Racksincor.DAL.Models;

namespace Racksincor.DAL.Services.Auth
{
    internal class LoginService : ILoginService
    {
        private ITokenService _tokenService;
        private UserManager<User> _userManager;

        public LoginService(UserManager<User> userManager, ITokenService tokenService)
        {
            _userManager = userManager;
            _tokenService = tokenService;
        }

        public async Task<string> Login(string email, string password)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user != null && await _userManager.CheckPasswordAsync(user, password))
            {
                return _tokenService.GenerateToken(user);
            }

            throw new InvalidOperationException("Invalid email or password.");
        }
    }
}
