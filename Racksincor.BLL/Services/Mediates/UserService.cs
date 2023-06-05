using FluentValidation;
using Racksincor.BLL.DTO.Queries;
using Racksincor.BLL.DTO.User;
using Racksincor.BLL.Interfaces;
using Racksincor.BLL.Interfaces.Outer;

namespace Racksincor.BLL.Services.Mediates
{
    public class UserService : IUserMediateService
    {
        private ILoginService _loginService;
        private IRepository<UserDTO, UserQuery> _repository;
        private IValidator<LoginDTO> _loginValidator;
        private IValidator<RegisterDTO> _registerValidator;
        private IValidator<UserUpdateDTO> _userUpdateValidator;

        public UserService(ILoginService loginService, IValidator<RegisterDTO> registerValidator, IRepository<UserDTO, UserQuery> repository, IValidator<UserUpdateDTO> userUpdateValidator, IValidator<LoginDTO> loginValidator)
        {
            _loginService = loginService;
            _registerValidator = registerValidator;
            _repository = repository;
            _userUpdateValidator = userUpdateValidator;
            _loginValidator = loginValidator;
        }

        public async Task<string> Login(LoginDTO user)
        {
            await _loginValidator.ValidateAndThrowAsync(user);

            return await _loginService.Login(user.Email, user.Password);
        }

        public async Task<IReadOnlyList<UserDTO>> ReadWithQuery(UserQuery query)
        {
            return await _repository.ReadWithQuery(query);
        }

        public async Task<UserDTO> Register(RegisterDTO user)
        {
            await _registerValidator.ValidateAndThrowAsync(user);

            return await _repository.Create(user);
        }

        public async Task<UserDTO> Update(UserUpdateDTO user)
        {
            await _userUpdateValidator.ValidateAndThrowAsync(user);

            return await _repository.Update(
                new UserDTO 
            {
                Email = user.Email,
                Password = user.Password,
            });
        }

        public async Task Delete(UserDTO user)
        {
            await _repository.Delete(user);
        }
    }
}
