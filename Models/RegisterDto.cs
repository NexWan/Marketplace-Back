namespace MarketplaceAPI.Models
{
    /*
     * RegisterDto class is a Data Transfer Object (DTO) used for user registration.
     * It contains properties for the username, email, password, and role.
     */
    public class RegisterDto
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; } // e.g., "Admin", "User"
    }
}