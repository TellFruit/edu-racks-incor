namespace Racksincor.BLL.Interfaces.Outer
{
    public interface ILoginService
    {
        Task<string> Login(string email, string password);
    }
}
