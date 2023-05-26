using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace Racksincor.DAL.Conventions
{
    internal class LowercaseTableNameConvention : IConvention
    {
        public void ProcessModelFinalized(IConventionModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Metadata.GetEntityTypes())
            {
                entityType.SetTableName(entityType.GetTableName().ToLowerInvariant());
            }
        }
    }
}
