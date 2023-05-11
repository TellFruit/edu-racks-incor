using Racksincor.BLL.DTO.Queries;
using Racksincor.BLL.Interfaces;
using Racksincor.DAL.Services.Repositories.Abstract;
using System.Data;
using Dapper;
using Racksincor.BLL.DTO;

namespace Racksincor.DAL.Services.Repositories
{
    internal class CompanyRepository : BaseRepository, IRepository<CompanyDTO, CompanyQuery>
    {
        public CompanyRepository(IDbConnection connection) : base(connection) { }

        public async Task<CompanyDTO> Create(CompanyDTO entity)
        {
            using (var transaction = _connection.BeginTransaction())
            {
                try
                {
                    DateTime now = DateTime.Now;

                    await _connection.ExecuteAsync(@"
                        INSERT INTO Companies (Name, Address, CreatedAt, UpdatedAt)
                            VALUES (@Name, @Address, @CreatedAt, @UpdatedAt)",
                        new
                        {
                            entity.Name,
                            entity.Address,
                            CreatedAt = now,
                            UpdatedAt = now
                        },
                        transaction);

                    var found = await _connection.QueryFirstAsync<CompanyDTO>(
                        "SELECT * FROM Companies WHERE CreatedAt = @CreatedAt",
                        new { CreatedAt = now },
                        transaction);

                    transaction.Commit();

                    return found;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.StackTrace);

                    transaction.Rollback();

                    return new CompanyDTO();
                }
            }
        }

        public async Task Delete(CompanyDTO entity)
        {
            using (var transaction = _connection.BeginTransaction())
            {
                try
                {
                    await _connection.ExecuteAsync(
                        "DELETE FROM Companies WHERE Id = @Id",
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

        public async Task<IReadOnlyList<CompanyDTO>> Read()
        {
            return (await _connection.QueryAsync<CompanyDTO>("SELECT * FROM Companies")).ToList();
        }

        public async Task<IReadOnlyList<CompanyDTO>> ReadWithQuery(CompanyQuery obj)
        {
            return await Read();
        }

        public async Task<CompanyDTO> Update(CompanyDTO entity)
        {
            using (var transaction = _connection.BeginTransaction())
            {
                try
                {
                    DateTime now = DateTime.Now;

                    await _connection.ExecuteAsync(
                        "UPDATE Companies SET Name = @Name, Address = @Address, UpdatedAt = @UpdatedAt WHERE Id = @Id",
                        new
                        {
                            entity.Id,
                            entity.Name,
                            entity.Address,
                            UpdatedAt = now
                        },
                        transaction);

                    transaction.Commit();

                    return await _connection.QueryFirstAsync<CompanyDTO>(
                        "SELECT * FROM Companies WHERE UpdatedAt = @UpdatedAt",
                        new { UpdatedAt = now });
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.StackTrace);

                    transaction.Rollback();

                    return new CompanyDTO();
                }
            }
        }
    }
}
