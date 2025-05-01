namespace MarketplaceAPI.Models
{

/*
     * UserProduct class represents a many-to-many relationship between users and products.
     * It contains properties for the user ID, product ID, and navigation properties to the User and Product entities.
*/
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