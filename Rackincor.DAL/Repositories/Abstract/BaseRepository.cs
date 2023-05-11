using System.Data;

namespace Racksincor.DAL.Repositories.Abstract
{
    internal abstract class BaseRepository : IDisposable
    {
        protected readonly IDbConnection _connection;

        public BaseRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public void Dispose()
        {
            _connection.Dispose();
        }
    }
}
