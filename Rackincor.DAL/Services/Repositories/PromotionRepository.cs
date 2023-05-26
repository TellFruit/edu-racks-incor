﻿using Dapper;
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
                        INSERT INTO Promotions (Discriminator, Name, ExpirationDate, Percenatage, GiftProductId, CreatedAt, UpdatedAt)
                            VALUES (@Discriminator, @Name, @ExpirationDate, @Percenatage, @GiftProductId, @CreatedAt, @UpdatedAt)",
                        new
                        {
                            CreatedAt = now,
                            UpdatedAt = now,
                            Discriminator = entity.GetType().Name,
                            Name = entity.GetPropertyValue("Name"),
                            ExpirationDate = entity.GetPropertyValue("ExpirationDate"),
                            Percenatage = entity.GetPropertyValue("Percenatage"),
                            GiftProductId = entity.GetPropertyValue("GiftProductId")
                        },
                        transaction);

                    transaction.Commit();

                    var found = await _connection.QueryFirstAsync<TEntity>(
                        "SELECT * FROM Promotions WHERE CreatedAt = @CreatedAt",
                        new { CreatedAt = now },
                        transaction);

                    return new TEntity();
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
            var sqlBuilder = new StringBuilder("SELECT * FROM Promotions WHERE 1 = 1");

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
                    string query = $"UPDATE Promotions SET UpdatedAt = @UpdatedAt, {columnValueList} WHERE Id = @Id";
                    _connection.Execute(
                        query,
                        new
                        {
                            entity,
                            UpdatedAt = now
                        });

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
