namespace Racksincor.DAL.Services
{
    internal static class ParseEntityExtension
    {
        public static object? GetPropertyValue<TEntity>(this TEntity entity, string name) where TEntity : class
        {
            return entity.GetType().GetProperty(name)?.GetValue(entity);
        }
    }
}
