using System.Data;

namespace Racksincor.DAL.Services.Repositories.Abstract
{
    // TODO: this should be renamed to something like DapperRepository
    internal abstract class BaseRepository : IDisposable
    {
        protected readonly IDbConnection _connection;

        public BaseRepository(IDbConnection connection)
        {
            _connection = connection;
            _connection.Open();
        }

        public void Dispose()
        {
            _connection.Close();
            _connection.Dispose();
        }
    }
}
