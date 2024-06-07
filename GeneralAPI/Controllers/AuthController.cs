using System.IdentityModel.Tokens.Jwt;
using System.Text;
using GeneralAPI.Entities.Models;
using GeneralAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace GeneralAPI.Controller;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly PostgreDbContext _context;
    private readonly IConfiguration _configuration;

    public AuthController(PostgreDbContext context, IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
        return Ok(user);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] User user)
    {
        var existingUser = await _context.Users.SingleOrDefaultAsync(u => u.Email == user.Email && u.Password == user.Password);
        if (existingUser == null)
        {
            return Unauthorized();
        }

        var token = GenerateJSONWebToken(existingUser);
        return Ok(new { token });
    }

    private string GenerateJSONWebToken(User user)
    {
        var key = Convert.FromBase64String(Convert.ToBase64String(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"])));
        var securityKey = new SymmetricSecurityKey(key);
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            null, null, null,
            expires: DateTime.Now.AddMinutes(120),
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }


}