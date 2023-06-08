using Racksincor.BLL.DTO.Queries;
using Racksincor.BLL.Interfaces;
using Racksincor.DAL.Services.Repositories.Abstract;
using System.Data;
using Dapper;
using Racksincor.BLL.DTO;
using System.Text;

namespace Racksincor.DAL.Services.Repositories
{
    internal class ProductRepository : BaseRepository, IRepository<ProductDTO, ProductQuery>
    {
        public ProductRepository(IDbConnection connection) : base(connection) { }

        public async Task<ProductDTO> Create(ProductDTO entity)
        {
            using (var transaction = _connection.BeginTransaction())
            {
                try
                {
                    DateTime now = DateTime.Now;

                    await _connection.ExecuteAsync(@"
                        INSERT INTO Products (Name, Price, IsInStock, ShopId, CreatedAt, UpdatedAt)
                            VALUES (@Name, @Price, @IsInStock, @ShopId, @CreatedAt, @UpdatedAt)",
                        new
                        {
                            entity.Name,
                            entity.Price,
                            entity.IsInStock,
                            entity.ShopId,
                            CreatedAt = now,
                            UpdatedAt = now
                        },
                        transaction);

                    var found = await _connection.QueryFirstAsync<ProductDTO>(
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

                    return new ProductDTO();
                }
            }
        }

        public async Task Delete(ProductDTO entity)
        {
            using (var transaction = _connection.BeginTransaction())
            {
                try
                {
                    await _connection.ExecuteAsync(
                        "DELETE FROM Products WHERE Id = @Id",
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

        public async Task<IReadOnlyList<ProductDTO>> ReadWithQuery(ProductQuery? obj)
        {
            var sqlBuilder = new StringBuilder("SELECT * FROM Products p");

            if (obj != null)
            {
                if (obj.RackId != default)
                {
                    sqlBuilder.Append(" INNER JOIN productrack pr ON p.Id = pr.ProductsId");
                    sqlBuilder.Append(" WHERE pr.RacksId = @RackId");
                }
                else
                {
                    sqlBuilder.Append(" WHERE 1 = 1");
                }

                if (obj.Id != default)
                {
                    sqlBuilder.Append(" AND Id = @Id");
                }

                if (obj.ShopId != default)
                {
                    sqlBuilder.Append(" AND ShopId = @ShopId");
                }
            }

            return (await _connection.QueryAsync<ProductDTO>(sqlBuilder.ToString(), obj)).ToList();
        }

        public async Task<ProductDTO> Update(ProductDTO entity)
        {
            using (var transaction = _connection.BeginTransaction())
            {
                try
                {
                    DateTime now = DateTime.Now;

                    await _connection.ExecuteAsync(
                        "UPDATE Products SET Name = @Name, Price = @Price, IsInStock = @IsInStock, UpdatedAt = @UpdatedAt WHERE Id = @Id",
                        new
                        {
                            entity.Id,
                            entity.Name,
                            entity.Price,
                            entity.IsInStock,
                            UpdatedAt = now
                        },
                        transaction);

                    transaction.Commit();

                    return await _connection.QueryFirstAsync<ProductDTO>(
                        "SELECT * FROM Products WHERE UpdatedAt = @UpdatedAt",
                        new { UpdatedAt = now });
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.StackTrace);

                    transaction.Rollback();

                    return new ProductDTO();
                }
            }
        }
    }
}
