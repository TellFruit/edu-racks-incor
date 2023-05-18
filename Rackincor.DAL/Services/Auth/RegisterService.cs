using Microsoft.AspNetCore.Identity;
using Racksincor.BLL.DTO.User;
using Racksincor.BLL.Interfaces.Outer;
using Racksincor.DAL.Models;

namespace Racksincor.DAL.Services.Auth
{
    internal class RegisterService : IRegisterService
    {
        private UserManager<User> _userManager;

        public RegisterService(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task Register(string email, string password)
        {
            User? user = new User
            {
                UserName = email,
                Email = email
            };

            var result = await _userManager.CreateAsync(user, password);
            if (!result.Succeeded)
            {
                throw new InvalidOperationException("Email is already taken.");
            }
        }
    }
}
