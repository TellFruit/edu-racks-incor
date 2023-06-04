using Racksincor.BLL.DTO.Abstract;

namespace Racksincor.BLL.DTO.User
{
    public class LoginDTO : BaseDTO<string>
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
