using Racksincor.DAL.Models;

namespace Racksincor.DAL.Interfaces
{
    internal interface ITokenService
    {
        public string GenerateToken(User user, IList<string> roles);
    }
}
