namespace Racksincor.DAL.Services
{
    internal static class ParseEntityExtension
    {
        public static object? GetPropertyValue<TEntity>(this TEntity entity, string name) where TEntity : class
        {
            return entity.GetType().GetProperty(name)?.GetValue(entity);
        }

        public static string GetColumnList<TEntity>(this TEntity entity) where TEntity : class
        {
            var propertyNames = entity
                .GetType()
                .GetProperties()
                .Where(p => !p.PropertyType.IsInterface && p.Name != "Id")
                .Select(p => p.Name);
            return string.Join(", ", propertyNames);
        }

        public static string GetPropertyValueList<TEntity>(this TEntity entity) where TEntity : class
        {
            var propertyValues = entity
                .GetType()
                .GetProperties()
                .Where(p => !p.PropertyType.IsInterface && p.Name != "Id")
                .Select(p => $"@{p.Name}");
            return string.Join(", ", propertyValues);
        }

        public static string GetColumnValueList<TEntity>(this TEntity entity) where TEntity : class
        {
            var propertyList = entity
                .GetType()
                .GetProperties()
                .Where(p => !p.PropertyType.IsInterface && p.Name != "Id")
                .Select(p => $"{p.Name} = @{p.Name}");
            return string.Join(", ", propertyList);
        }
    }
}
