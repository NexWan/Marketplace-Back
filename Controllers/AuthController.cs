using MarketplaceAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using MarketplaceAPI.Contexts;
using Microsoft.AspNetCore.Authorization;
using MarketplaceAPI.Services;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly IConfiguration _config;
    private readonly JwtService _jwtService;

    public AuthController(AppDbContext context, IConfiguration config, JwtService jwtService)
    {
        _context = context;
        _config = config;
        _jwtService = jwtService;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginDto login)
    {
        var user = _context.Users.FirstOrDefault(u => u.Username == login.Username);
        if (user == null || !BCrypt.Net.BCrypt.Verify(login.Password, user.Password))
            return Unauthorized("Invalid credentials");

        var token = _jwtService.GenerateToken(user);

        Response.Cookies.Append("jwt", token, new CookieOptions
        {
            HttpOnly = true,
            Secure = true,
            SameSite = SameSiteMode.None,
            Expires = DateTimeOffset.UtcNow.AddHours(2)
        });
        return Ok(new { message  = "Login succesful" });
    }

    [HttpGet("me")]
    [Authorize]
    public IActionResult Me()
    {
        var identity = HttpContext.User.Identity as ClaimsIdentity;
        if (identity == null || !identity.IsAuthenticated)
            return Unauthorized("User not authenticated");

        var userId = identity.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        var username = identity.FindFirst(ClaimTypes.Name)?.Value;
        var role = identity.FindFirst(ClaimTypes.Role)?.Value;
        var email = identity.FindFirst(ClaimTypes.Email)?.Value;
        var profilePictureUrl = identity.FindFirst("ProfilePictureUrl")?.Value;

        return Ok(new { id = userId, username, role, email, profilePictureUrl });
    }

    [HttpPost("Logout")]
    public IActionResult Logout()
    {
        Response.Cookies.Delete("jwt");
        return Ok(new { message = "Logout successful" });
    }

    
}
