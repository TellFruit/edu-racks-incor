using Racksincor.BLL.DTO.Queries;
using Racksincor.BLL.Interfaces;
using Racksincor.DAL.Services.Repositories.Abstract;
using System.Data;
using Dapper;
using Racksincor.BLL.DTO;
using System.Text;

namespace Racksincor.DAL.Services.Repositories
{
    internal class ReactionRepository : BaseRepository, IRepository<ReactionDTO, ReactionQuery>
    {
        public ReactionRepository(IDbConnection connection) : base(connection) { }

        public async Task<ReactionDTO> Create(ReactionDTO entity)
        {
            using (var transaction = _connection.BeginTransaction())
            {
                try
                {
                    DateTime now = DateTime.Now;

                    await _connection.ExecuteAsync(@"
                        INSERT INTO Reactions (IsPositive, UserId, ProductId, CreatedAt, UpdatedAt)
                            VALUES (@IsPositive, @UserId, @ProductId, @CreatedAt, @UpdatedAt)",
                        new
                        {
                            entity.IsPositive,
                            entity.UserId,
                            entity.ProductId,
                            CreatedAt = now,
                            UpdatedAt = now
                        },
                        transaction);

                    var found = await _connection.QueryFirstAsync<ReactionDTO>(
                        "SELECT * FROM Reactions WHERE CreatedAt = @CreatedAt",
                        new { CreatedAt = now },
                        transaction);

                    transaction.Commit();

                    return found;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.StackTrace);

                    transaction.Rollback();

                    return new ReactionDTO();
                }
            }
        }

        public async Task Delete(ReactionDTO entity)
        {
            using (var transaction = _connection.BeginTransaction())
            {
                try
                {
                    await _connection.ExecuteAsync(
                        "DELETE FROM Reactions WHERE Id = @Id",
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

        public async Task<IReadOnlyList<ReactionDTO>> ReadWithQuery(ReactionQuery? obj)
        {
            var sqlBuilder = new StringBuilder("SELECT * FROM Reactions WHERE 1 = 1");

            if (obj != null)
            {
                if (obj.Id != default)
                {
                    sqlBuilder.Append(" AND Id = @Id");
                }
            }

            return (await _connection.QueryAsync<ReactionDTO>(sqlBuilder.ToString(), obj)).ToList();
        }

        public async Task<ReactionDTO> Update(ReactionDTO entity)
        {
            using (var transaction = _connection.BeginTransaction())
            {
                try
                {
                    DateTime now = DateTime.Now;

                    await _connection.ExecuteAsync(
                        "UPDATE Reactions SET IsPositive = @IsPositive, UserId = @UserId, ProductId = @ProductId, UpdatedAt = @UpdatedAt WHERE Id = @Id",
                        new
                        {
                            entity.Id,
                            entity.IsPositive,
                            entity.UserId,
                            entity.ProductId,
                            UpdatedAt = now
                        },
                        transaction);

                    transaction.Commit();

                    return await _connection.QueryFirstAsync<ReactionDTO>(
                        "SELECT * FROM Reactions WHERE UpdatedAt = @UpdatedAt",
                        new { UpdatedAt = now });
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.StackTrace);

                    transaction.Rollback();

                    return new ReactionDTO();
                }
            }
        }
    }
}
