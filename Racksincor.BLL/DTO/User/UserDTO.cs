using Racksincor.BLL.DTO.Abstract;

namespace Racksincor.BLL.DTO.User
{
    public class UserDTO : BaseDTO<string>
    {
        public string Email { get; set; }
        public string? Role { get; set; }
        public int ShopId { get; set; }
        public string? Password { get; set; }
    }
}
