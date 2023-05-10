﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Racksincor.DAL.Models;

namespace Racksincor.DAL
{
    public class RacksincorDbContext : IdentityDbContext<User>
    {
        public RacksincorDbContext(DbContextOptions<RacksincorDbContext> options)
            : base(options) { }

        public DbSet<User> Users { get; set; }
    }
}
