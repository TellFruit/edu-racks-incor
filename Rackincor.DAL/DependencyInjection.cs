using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Racksincor.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;
using Npgsql;

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
                return new NpgsqlConnection(config.GetConnectionString("ConnectionString"));
            });
        }
    }
}
