using System.ComponentModel.DataAnnotations;

namespace MarketplaceAPI.Models
{
    /*
     * User class represents a user in the marketplace.
     * It contains properties for the user's ID, username, email, password, and role.
     */
    public class User
    {
        public int Id { get; set; }
        
        [Required, MaxLength(50)]
        public string Username { get; set; }
        
        [Required, EmailAddress]
        public string Email { get; set; }
        
        [Required, MinLength(6)]
        public string Password { get; set; }
        
        [Required]
        public string Role { get; set; } // e.g., "Admin", "User"

        public ICollection<UserProduct> UserProducts { get; set; } = new List<UserProduct>();
    }
}