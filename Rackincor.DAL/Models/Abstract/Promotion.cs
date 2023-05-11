namespace Racksincor.DAL.Models.Abstract
{
    public abstract class Promotion : BaseEntity
    {
        public string Name { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
