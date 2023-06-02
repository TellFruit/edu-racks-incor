using Dapper;
using Microsoft.AspNetCore.Identity;
using Racksincor.BLL.DTO.Queries;
using Racksincor.BLL.DTO.User;
using Racksincor.BLL.Interfaces;
using Racksincor.DAL.Models;
using Racksincor.DAL.Services.Repositories.Abstract;
using System.Data;
using System.Text;

namespace Racksincor.DAL.Services.Repositories
{
    internal class UserRepository : BaseRepository, IRepository<UserDTO, UserQuery>
    {
        private readonly UserManager<User> _userManager;

        public UserRepository(IDbConnection connection, UserManager<User> userManager) : base(connection)
        {
            _userManager = userManager;
        }

        public async Task<UserDTO> Create(UserDTO entity)
        {
            var user = new User
            {
                UserName = entity.Email,
                Email = entity.Email
            };

            var result = await _userManager.CreateAsync(user, entity.Password);
            if (!result.Succeeded)
            {
                throw new InvalidOperationException("Invalid email or password.");
            }

            await _userManager.AddToRoleAsync(user, entity.Role);

            var found = await _userManager.FindByEmailAsync(entity.Email);

            return new UserDTO 
            { 
                Email = found.Email
            };
        }

        public async Task Delete(UserDTO entity)
        {
            var found = await _userManager.FindByEmailAsync(entity.Email);

            await _userManager.DeleteAsync(found);
        }

        public async Task<IReadOnlyList<UserDTO>> ReadWithQuery(UserQuery? obj)
        {
            var sqlBuilder = new StringBuilder("SELECT * FROM AspNetUsers WHERE 1 = 1");

            if (obj != null)
            {
                if (obj.ShopId != default)
                {
                    sqlBuilder.Append(" AND Shop = @ShopId");
                }
            }

            return (await _connection.QueryAsync<UserDTO>(sqlBuilder.ToString(), obj)).ToList();
        }

        public async Task<UserDTO> Update(UserDTO entity)
        {
            var found = await _userManager.FindByEmailAsync(entity.Email);

            var newPasswordHash = _userManager.PasswordHasher.HashPassword(found, entity.Password);

            found.Email = entity.Email;
            found.PasswordHash = newPasswordHash;

            var result = await _userManager.UpdateAsync(found);

            if (result.Succeeded)
            {
                found = await _userManager.FindByEmailAsync(entity.Email);
                
                return new UserDTO
                {
                    Email = found.Email
                };
            }

            throw new InvalidOperationException("Updating data is invalid.");
        }
    }
}
