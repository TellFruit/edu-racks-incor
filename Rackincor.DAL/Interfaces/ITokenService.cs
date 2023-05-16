using Racksincor.DAL.Models;

namespace Racksincor.DAL.Interfaces
{
    internal interface ITokenService
    {
        public Task<string> GenerateToken(User user);
    }
}
