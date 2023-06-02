using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Racksincor.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;
using Npgsql;
using Racksincor.DAL.Interfaces;
using Racksincor.DAL.Services.Auth;
using Racksincor.BLL.Interfaces.Outer;
using Racksincor.BLL.Interfaces;
using Racksincor.DAL.Services.Repositories;
using Racksincor.BLL.DTO;
using Racksincor.BLL.DTO.Queries;
using Racksincor.BLL.DTO.User;

namespace Racksincor.DAL
{
    public static class DependencyInjection
    {
        public static void AddDbContext(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<RacksincorDbContext>(options =>
                options.UseNpgsql(config["ConnectionString"]));
        }

        public static void AddIdentity(this IServiceCollection services)
        {
            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<RacksincorDbContext>()
                .AddDefaultTokenProviders();
        }

        public static void AddDbConnection(this IServiceCollection services, IConfiguration config)
        {
            services.AddTransient<IDbConnection>(
                provider =>
            {
                return new NpgsqlConnection(config["ConnectionString"]);
            });
        }

        public static void AddAuthServices(this IServiceCollection services)
        {
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<ILoginService, LoginService>();
        } 

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<,>), typeof(PromotionRepository<,>));
            services.AddScoped<IRepository<CompanyDTO, CompanyQuery>, CompanyRepository>();
            services.AddScoped<IRepository<ShopDTO, ShopQuery>, ShopRepository>();
            services.AddScoped<IRepository<ProductDTO, ProductQuery>, ProductRepository>();
            services.AddScoped<IRepository<ReactionDTO, ReactionQuery>, ReactionRepository>();
            services.AddScoped<IRepository<RackDTO, RackQuery>, RackRepository>();
            services.AddScoped<IRepository<UserDTO, UserQuery>, UserRepository>();
        }
    }
}
