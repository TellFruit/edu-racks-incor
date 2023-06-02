using FluentValidation;
using Racksincor.BLL.DTO.Queries;
using Racksincor.BLL.DTO.User;
using Racksincor.BLL.Interfaces;
using Racksincor.BLL.Interfaces.Outer;

namespace Racksincor.BLL.Services.Mediates
{
    public class AuthService : IUserMediateService
    {
        private ILoginService _loginService;
        private IRepository<UserDTO, UserQuery> _repository;
        private IValidator<UserDTO> _userValidator;
        private IValidator<RegisterDTO> _registerValidator;

        public AuthService(ILoginService loginService, IValidator<UserDTO> userValidator, IValidator<RegisterDTO> registerValidator, IRepository<UserDTO, UserQuery> repository)
        {
            _loginService = loginService;
            _userValidator = userValidator;
            _registerValidator = registerValidator;
            _repository = repository;
        }

        public async Task<string> Login(UserDTO user)
        {
            await _userValidator.ValidateAndThrowAsync(user);

            return await _loginService.Login(user.Email, user.Password);
        }

        public Task<IReadOnlyList<UserDTO>> ReadWithQuery(UserQuery query)
        {
            throw new NotImplementedException();
        }

        public async Task<UserDTO> Register(RegisterDTO user)
        {
            await _registerValidator.ValidateAndThrowAsync(user);

            return await _repository.Create(user);
        }


        public async Task<UserDTO> Update(UserDTO user)
        {
            await _userValidator.ValidateAndThrowAsync(user);

            return await _repository.Update(user);
        }

        public async Task Delete(UserDTO user)
        {
            await _repository.Delete(user);
        }
    }
}
