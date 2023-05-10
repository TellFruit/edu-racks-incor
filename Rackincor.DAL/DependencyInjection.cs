using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Rackincor.DAL.Models;
using System.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Rackincor.DAL
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
            services.AddIdentityCore<User>()
                .AddEntityFrameworkStores<RacksincorDbContext>()
                .AddRoles<IdentityRole>()
                .AddDefaultTokenProviders();
        }
    }
}
