namespace MarketplaceAPI.Models
{
    /*
     * UserDto class is a Data Transfer Object (DTO) used for transferring user data.
     * It contains properties for the user's ID, username, email, and role.
     */
    public class UserDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Role { get; set; } // e.g., "Admin", "User"
        public string? ProfilePictureUrl { get; set; } // Optional property for profile picture URL
    }
}