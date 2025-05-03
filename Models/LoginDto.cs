namespace MarketplaceAPI.Models {

    /*
     * LoginDto class is a Data Transfer Object (DTO) used for user login.
     * It contains properties for the username and password.
     */

    public class LoginDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

}