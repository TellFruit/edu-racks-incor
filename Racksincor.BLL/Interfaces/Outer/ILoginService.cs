namespace Racksincor.BLL.Interfaces.Outer
{
    public interface ILoginService
    {
        public Task<string> Login(string email, string password);
    }
}
