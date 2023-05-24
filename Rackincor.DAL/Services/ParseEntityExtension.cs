using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Racksincor.DAL.Services
{
    internal static class ParseEntityExtension
    {
        public static string GetColumnList<TEntity>(this TEntity entity) where TEntity : class
        {
            var propertyNames = entity.GetType().GetProperties().Select(p => p.Name);
            return string.Join(", ", propertyNames);
        }

        public static string GetPropertyValueList<TEntity>(this TEntity entity) where TEntity : class
        {
            var propertyValues = entity.GetType().GetProperties().Select(p => $"@{p.Name}");
            return string.Join(", ", propertyValues);
        }

        public static string GetColumnValueList<TEntity>(this TEntity entity) where TEntity : class
        {
            var propertyList = entity.GetType().GetProperties().Select(p => $"{p.Name} = @{p.Name}");
            return string.Join(", ", propertyList);
        }
    }
}
