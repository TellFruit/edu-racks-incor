namespace Racksincor.DAL.Models.Abstract
{
    internal abstract class Promotion : BaseEntity
    {
        public string Name { get; set; }
        public DateTime ExpirationDate { get; set; }

        // Many-to-Many relation: Promotion and Product
        public ICollection<Product> Products { get; set; }
    }
}
