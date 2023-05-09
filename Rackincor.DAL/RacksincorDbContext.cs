using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Rackincor.DAL.Models;

namespace Rackincor.DAL
{
    public class RacksincorDbContext : IdentityDbContext<User>
    {
        public RacksincorDbContext(DbContextOptions<RacksincorDbContext> options)
            : base(options) { }

        public DbSet<User> Users { get; set; }
    }
}
