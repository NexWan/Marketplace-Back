using MarketplaceAPI.Contexts;
using Microsoft.AspNetCore.Mvc;
using MarketplaceAPI.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using MarketplaceAPI.Services;

namespace MarketplaceAPI.Controllers {

    [ApiController]
    [Route("api/[controller]")]
    public class UserController: ControllerBase {
        private readonly AppDbContext _context;
        private readonly IConfiguration _config;
        private readonly JwtService _jwtService;

        public UserController(AppDbContext context, IConfiguration config, JwtService jwtService) {
            _context = context;
            _config = config;
            _jwtService = jwtService;
        }

        [Authorize]
        [HttpPut("update")]
        public IActionResult UpdateUser([FromBody] UserDto userDto)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity == null || !identity.IsAuthenticated)
                return Unauthorized("User not authenticated");

            var userId = identity.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var user = _context.Users.FirstOrDefault(u => u.Id.ToString() == userId);
            if (user == null)
                return NotFound("User not found");

            user.Username = userDto.Username ?? user.Username;
            user.Email = userDto.Email ?? user.Email;
            user.ProfilePictureUrl = userDto.ProfilePictureUrl ?? user.ProfilePictureUrl;

            _context.Users.Update(user);
            _context.SaveChanges();

            var newToken = _jwtService.GenerateToken(user);

            Response.Cookies.Append("jwt", newToken, new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.None,
                Expires = DateTimeOffset.UtcNow.AddHours(2)
            });

            return Ok(new { message = "User updated successfully" });
        }

    }
    
}