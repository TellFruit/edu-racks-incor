using Microsoft.EntityFrameworkCore;
using Racksincor.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Racksincor.DAL
{
    internal static class ContextExtension
    {
        public static void Configure(this ModelBuilder builder)
        {
            builder.Entity<Reaction>()
                .HasKey(sc => new { sc.UserId, sc.ProductId });
        }
    }
}
