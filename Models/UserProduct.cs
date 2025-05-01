namespace MarketplaceAPI.Models
{

    public class UserProduct
    {
        public int UserId { get; set; }
        public int ProductId { get; set; }

        public User User { get; set; }
        public Product Product { get; set; }

        // Custom fields
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public bool IsActive { get; set; } = true;
    }
}