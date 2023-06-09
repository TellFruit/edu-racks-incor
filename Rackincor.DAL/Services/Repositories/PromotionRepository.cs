using Dapper;
using Racksincor.BLL.DTO;
using Racksincor.BLL.DTO.Abstract;
using Racksincor.BLL.DTO.Queries;
using Racksincor.BLL.Interfaces;
using Racksincor.DAL.Services.Repositories.Abstract;
using System.Data;
using System.Text;

namespace Racksincor.DAL.Services.Repositories
{
    internal class PromotionRepository<TEntity, TQuery> : BaseRepository, IRepository<TEntity, TQuery>
        where TEntity : PromotionDTO, new()
        where TQuery : PromotionQuery
    {
        public PromotionRepository(IDbConnection connection) : base(connection) { }

        public async Task<TEntity> Create(TEntity entity)
        {
            using (var transaction = _connection.BeginTransaction())
            {
                try
                {
                    DateTime now = DateTime.Now;

                    await _connection.ExecuteAsync(@"
                        INSERT INTO Promotions (Discriminator, Name, ExpirationDate, Percenatage, GiftProductId, ShopId, CreatedAt, UpdatedAt)
                            VALUES (@Discriminator, @Name, @ExpirationDate, @Percenatage, @GiftProductId, @ShopId, @CreatedAt, @UpdatedAt)",
                        new
                        {
                            Discriminator = entity.GetType().Name,
                            Name = entity.Name,
                            ExpirationDate = entity.ExpirationDate,
                            Percenatage = entity.GetPropertyValue("Percenatage"),
                            GiftProductId = entity.GetPropertyValue("GiftProductId"),
                            ShopId = entity.ShopId,
                            CreatedAt = now,
                            UpdatedAt = now
                        },
                        transaction);

                    var found = await _connection.QueryFirstAsync<TEntity>(
                        "SELECT * FROM Promotions WHERE CreatedAt = @CreatedAt",
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
                        "DELETE FROM Promotions WHERE Id = @Id",
                        new { entity.Id },
                        transaction);

                    await _connection.ExecuteAsync(
                        "DELETE FROM ProductPromotion WHERE PromotionsId = @PromotionsId",
                        new { PromotionsId = entity.Id },
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
            var sqlBuilder = new StringBuilder("SELECT * FROM Promotions WHERE 1 = 1");

            if (obj != null)
            {
                if (obj.Id != default)
                {
                    sqlBuilder.Append(" AND Id = @Id");
                }
                
                if (obj.Discriminator != default)
                {
                    sqlBuilder.Append(" AND Discriminator = @Discriminator");
                }

                if (obj.ShopId != default)
                {
                    sqlBuilder.Append(" AND ShopId = @ShopId");
                }
            }

            return (await _connection.QueryAsync<TEntity>(
                sqlBuilder.ToString(), 
                new
                {
                    Id = obj?.Id,
                    ShopId = obj?.ShopId,
                    Discriminator = obj?.Discriminator
                }))
                .ToList();
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            using (var transaction = _connection.BeginTransaction())
            {
                try
                {
                    DateTime now = DateTime.Now;

                    _connection.Execute(@"
                        UPDATE Promotions
                        SET Name = @Name, ExpirationDate = @ExpirationDate, Percenatage = @Percenatage, GiftProductId = @GiftProductId, UpdatedAt = @UpdatedAt
                        WHERE Id = @Id",
                        new
                        {
                            Id = entity.Id,
                            Name = entity.Name,
                            ExpirationDate = entity.ExpirationDate,
                            Percenatage = entity.GetPropertyValue("Percenatage"),
                            GiftProductId = entity.GetPropertyValue("GiftProductId"),
                            UpdatedAt = now
                        });

                    if (entity.Products == null)
                    {
                        entity.Products = new List<ProductDTO>();
                    }

                    if (entity.Products.Any())
                    {
                        await _connection.ExecuteAsync(
                            "DELETE FROM ProductPromotion WHERE PromotionsId = @PromotionsId",
                            new { PromotionsId = entity.Id },
                            transaction);
                    }

                    foreach (var product in entity.Products)
                    {
                        await _connection.ExecuteAsync(
                            "INSERT INTO ProductPromotion (PromotionsId, ProductsId) VALUES (@PromotionsId, @ProductsId)",
                            new
                            {
                                ProductsId = product.Id,
                                PromotionsId = entity.Id
                            },
                            transaction);
                    }

                    transaction.Commit();

                    return await _connection.QueryFirstAsync<TEntity>(
                        "SELECT * FROM Promotions WHERE UpdatedAt = @UpdatedAt",
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
