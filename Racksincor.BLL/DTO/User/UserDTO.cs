using Racksincor.BLL.DTO.Abstract;

namespace Racksincor.BLL.DTO.User
{
    public class UserDTO : BaseDTO
    {
        public string Email { get; set; }
        public string? Role { get; set; }
        public string ShopId { get; set; }
        public string Password { get; set; }
    }
}
