using Racksincor.BLL.DTO.User;

namespace Racksincor.BLL.Interfaces.Outer
{
    public interface IRegisterService
    {
        Task Register(string email, string password);
    }
}
