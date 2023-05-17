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

        public async Task Register(RegisterDTO registerDTO)
        {
            User? user = new User
            {
                UserName = registerDTO.Email,
                Email = registerDTO.Email
            };

            var result = await _userManager.CreateAsync(user, registerDTO.Password);
            if (!result.Succeeded)
            {
                throw new InvalidOperationException("Email is already taken.");
            }
        }
    }
}
