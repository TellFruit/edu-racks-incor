using Racksincor.BLL.DTO.Queries;
using Racksincor.BLL.Interfaces;
using Racksincor.DAL.Services.Repositories.Abstract;
using System.Data;
using Dapper;
using System.Text;
using Racksincor.BLL.DTO;

namespace Racksincor.DAL.Services.Repositories
{
    internal class RackRepository : BaseRepository, IRepository<RackDTO, RackQuery>
    {
        public RackRepository(IDbConnection connection) : base(connection) { }

        public async Task<RackDTO> Create(RackDTO entity)
        {
            using (var transaction = _connection.BeginTransaction())
            {
                try
                {
                    DateTime now = DateTime.Now;

                    await _connection.ExecuteAsync(@"
                        INSERT INTO Racks (Name, ShopId, CreatedAt, UpdatedAt)
                            VALUES (@Name, @ShopId, @CreatedAt, @UpdatedAt)",
                        new
                        {
                            entity.Name,
                            entity.ShopId,
                            CreatedAt = now,
                            UpdatedAt = now
                        },
                        transaction);

                    var found = await _connection.QueryFirstAsync<RackDTO>(
                        "SELECT * FROM Racks WHERE CreatedAt = @CreatedAt",
                        new { CreatedAt = now },
                        transaction);

                    transaction.Commit();

                    return found;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.StackTrace);

                    transaction.Rollback();

                    return new RackDTO();
                }
            }
        }

        public async Task Delete(RackDTO entity)
        {
            using (var transaction = _connection.BeginTransaction())
            {
                try
                {
                    await _connection.ExecuteAsync(
                        "DELETE FROM Racks WHERE Id = @Id",
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

        public async Task<IReadOnlyList<RackDTO>> ReadWithQuery(RackQuery? query)
        {
            var sqlBuilder = new StringBuilder("SELECT * FROM Racks WHERE 1 = 1");

            if (query != null)
            {
                if (query.Id != default)
                {
                    sqlBuilder.Append(" AND Id = @Id");
                }

                if (query.ShopId != default)
                {
                    sqlBuilder.Append(" AND ShopId = @ShopId");
                }
            }

            return (await _connection.QueryAsync<RackDTO>(sqlBuilder.ToString(), query)).ToList();
        }

        public async Task<RackDTO> Update(RackDTO entity)
        {
            using (var transaction = _connection.BeginTransaction())
            {
                try
                {
                    DateTime now = DateTime.Now;

                    await _connection.ExecuteAsync(
                        "UPDATE Racks SET Name = @Name, UpdatedAt = @UpdatedAt WHERE Id = @Id",
                        new
                        {
                            entity.Id,
                            entity.Name,
                            UpdatedAt = now
                        },
                        transaction);

                    if (entity.Products.Any())
                    {
                        await _connection.ExecuteAsync(
                            "DELETE FROM ProductRack WHERE RacksId = @RackId",
                            new
                            {
                                RackId = entity.Id
                            },
                            transaction);
                    }

                    foreach(var product in entity.Products)
                    {
                        await _connection.ExecuteAsync(
                            "INSERT INTO ProductRack (ProductsId, RacksId) VALUE (@ProductId, @RackId)",
                            new
                            {
                                ProductId = product.Id,
                                RackId = entity.Id
                            },
                            transaction);
                    }

                    transaction.Commit();

                    return await _connection.QueryFirstAsync<RackDTO>(
                        "SELECT * FROM Racks WHERE UpdatedAt = @UpdatedAt",
                        new { UpdatedAt = now });
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.StackTrace);

                    transaction.Rollback();

                    return new RackDTO();
                }
            }
        }
    }
}
