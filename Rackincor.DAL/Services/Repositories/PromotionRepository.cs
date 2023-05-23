using Dapper;
using Racksincor.BLL.DTO.Abstract;
using Racksincor.BLL.DTO.Queries;
using Racksincor.BLL.Interfaces;
using Racksincor.DAL.Services.Repositories.Abstract;
using System.Data;
using System.Text;

namespace Racksincor.DAL.Services.Repositories
{
    internal class PromotionRepositor<TEntity, TQuery> : BaseRepository, IRepository<TEntity, TQuery>
        where TEntity : PromotionDTO, new()
        where TQuery : PromotionQuery
    {
        public PromotionRepositor(IDbConnection connection) : base(connection) { }

        public async Task<TEntity> Create(TEntity entity)
        {
            using (var transaction = _connection.BeginTransaction())
            {
                try
                {
                    DateTime now = DateTime.Now;

                    string columnList = entity.GetColumnList();
                    string valueList = entity.GetPropertyValueList();
                    string query = $"INSERT INTO Promotion (CreatedAt, {columnList}) VALUES (@CreatedAt, {valueList})";

                    await _connection.ExecuteAsync(
                        query,
                        new
                        {
                            entity,
                            CreatedAt = now
                        },
                        transaction);

                    var found = await _connection.QueryFirstAsync<TEntity>(
                        "SELECT * FROM Products WHERE CreatedAt = @CreatedAt",
                        new { CreatedAt = now },
                        transaction);

                    transaction.Commit();

                    return found;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.StackTrace);

                    transaction.Rollback();

                    return new TEntity();
                }
            }
        }

        public async Task Delete(TEntity entity)
        {
            using (var transaction = _connection.BeginTransaction())
            {
                try
                {
                    await _connection.ExecuteAsync(
                        "DELETE FROM Promotion WHERE Id = @Id",
                        new { entity.Id },
                        transaction);

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.StackTrace);

                    transaction.Rollback();
                }
            }
        }

        public async Task<IReadOnlyList<TEntity>> ReadWithQuery(TQuery? obj)
        {
            var sqlBuilder = new StringBuilder("SELECT * FROM Products WHERE 1 = 1");

            if (obj != null)
            {
                if (obj.Id != default)
                {
                    sqlBuilder.Append(" AND Id = @Id");
                }
            }

            return (await _connection.QueryAsync<TEntity>(sqlBuilder.ToString(), obj)).ToList();
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            using (var transaction = _connection.BeginTransaction())
            {
                try
                {
                    DateTime now = DateTime.Now;

                    string columnValueList = entity.GetColumnValueList();
                    string query = $"UPDATE Promotion SET UpdatedAt = @UpdatedAt, {columnValueList} WHERE Id = @Id";
                    _connection.Execute(
                        query,
                        new
                        {
                            entity,
                            UpdatedAt = now
                        });

                    transaction.Commit();

                    return await _connection.QueryFirstAsync<TEntity>(
                        "SELECT * FROM Products WHERE UpdatedAt = @UpdatedAt",
                        new { UpdatedAt = now });
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.StackTrace);

                    transaction.Rollback();

                    return new TEntity();
                }
            }
        }
    }
}
