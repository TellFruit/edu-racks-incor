using Racksincor.BLL.DTO.Abstract;

namespace Racksincor.BLL.DTO.User
{
    public class RegisterDTO : UserDTO
    {
        public string PasswordConfirm { get; set; }
    }
}
