using Racksincor.BLL.Interfaces;
using Racksincor.DAL.Services.Repositories.Abstract;
using System.Data;
using Dapper;
using Racksincor.BLL.DTO;
using Racksincor.BLL.DTO.Queries;
using System.Text;

namespace Racksincor.DAL.Services.Repositories
{
    internal class ShopRepository : BaseRepository, IRepository<ShopDTO, ShopQuery>
    {
        public ShopRepository(IDbConnection connection) : base(connection) { }

        public async Task<ShopDTO> Create(ShopDTO entity)
        {
            using (var transaction = _connection.BeginTransaction())
            {
                try
                {
                    DateTime now = DateTime.Now;

                    await _connection.ExecuteAsync(@"
                        INSERT INTO Shops (Name, Address, CompanyId, CreatedAt, UpdatedAt)
                            VALUES (@Name, @Address, @CompanyId, @CreatedAt, @UpdatedAt)",
                        new
                        {
                            entity.Name,
                            entity.Address,
                            entity.CompanyId,
                            CreatedAt = now,
                            UpdatedAt = now
                        },
                        transaction);

                    var found = await _connection.QueryFirstAsync<ShopDTO>(
                        "SELECT * FROM Shops WHERE CreatedAt = @CreatedAt",
                        new { CreatedAt = now },
                        transaction);

                    transaction.Commit();

                    return found;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.StackTrace);

                    transaction.Rollback();

                    return new ShopDTO();
                }
            }
        }

        public async Task Delete(ShopDTO entity)
        {
            using (var transaction = _connection.BeginTransaction())
            {
                try
                {
                    await _connection.ExecuteAsync(
                        "DELETE FROM Shops WHERE Id = @Id",
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

        public async Task<IReadOnlyList<ShopDTO>> ReadWithQuery(ShopQuery obj)
        {
            var sqlBuilder = new StringBuilder("SELECT * FROM Shops WHERE 1 = 1");

            if (obj != null)
            {
                if (obj.CompanyId != default)
                {
                    sqlBuilder.Append(" AND CompanyId = @CompanyId");
                }
                else if (obj.Id != default)
                {
                    sqlBuilder.Append(" AND Id = @Id");
                }
            }

            return (await _connection.QueryAsync<ShopDTO>(sqlBuilder.ToString(), obj)).ToList();
        }


        public async Task<ShopDTO> Update(ShopDTO entity)
        {
            using (var transaction = _connection.BeginTransaction())
            {
                try
                {
                    DateTime now = DateTime.Now;

                    await _connection.ExecuteAsync(
                        "UPDATE Shops SET Name = @Name, Address = @Address, CompanyId = @CompanyId, UpdatedAt = @UpdatedAt WHERE Id = @Id",
                        new
                        {
                            entity.Id,
                            entity.Name,
                            entity.Address,
                            entity.CompanyId,
                            UpdatedAt = now
                        },
                        transaction);

                    transaction.Commit();

                    return await _connection.QueryFirstAsync<ShopDTO>(
                        "SELECT * FROM Shops WHERE UpdatedAt = @UpdatedAt",
                        new { UpdatedAt = now });
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.StackTrace);

                    transaction.Rollback();

                    return new ShopDTO();
                }
            }
        }
    }
}
