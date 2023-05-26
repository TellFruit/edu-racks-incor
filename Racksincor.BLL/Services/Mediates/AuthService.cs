using FluentValidation;
using Racksincor.BLL.DTO.User;
using Racksincor.BLL.Interfaces;
using Racksincor.BLL.Interfaces.Outer;

namespace Racksincor.BLL.Services.Mediates
{
    public class AuthService : IAuthService
    {
        private ILoginService _loginService;
        private IRegisterService _registerService;
        private IValidator<UserDTO> _userValidator;
        private IValidator<RegisterDTO> _registerValidator;

        public AuthService(ILoginService loginService, IRegisterService registerService, IValidator<UserDTO> userValidator, IValidator<RegisterDTO> registerValidator)
        {
            _loginService = loginService;
            _registerService = registerService;
            _userValidator = userValidator;
            _registerValidator = registerValidator;
        }

        public async Task<string> Login(UserDTO user)
        {
            await _userValidator.ValidateAndThrowAsync(user);

            return await _loginService.Login(user.Email, user.Password);
        }

        public async Task Register(RegisterDTO user)
        {
            await _registerValidator.ValidateAndThrowAsync(user);

            await _registerService.Register(user.Email, user.Password, user.Role);
        }
    }
}
