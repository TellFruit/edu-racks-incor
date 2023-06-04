using Racksincor.BLL.DTO.Abstract;

namespace Racksincor.BLL.DTO.User
{
    public class UserUpdateDTO : BaseDTO<string>
    {
        public string Email { get; set; }
        public string? Password { get; set; }
        public string? PasswordConfirm { get; set; }
    }
}
