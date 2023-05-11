namespace Racksincor.DAL.Models
{
    public class Reaction
    {
        public bool IsPositive { get; set; }

        // Many-to-Many relation: User-Product
        public string UserId { get; set; }
        public User User { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
