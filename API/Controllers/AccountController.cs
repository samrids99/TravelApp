using Microsoft.AspNetCore.Mvc;
using API.Data;
using API.Entities;
using System.Security.Cryptography;
using System.Text;
using Microsoft.EntityFrameworkCore;
using API.DTOs;

namespace API.Controllers;

public class AccountController : BaseApiController
{
    private readonly DataContext _context;


    public AccountController(DataContext context)
    {
        _context = context;
    }

    [HttpPost("register")]
    public async Task<ActionResult<AppUser>> Register(RegisterDto registerDto)
    {

        if (await UserExists(registerDto.Username)) return BadRequest("Username is taken");

        using var hmac = new HMACSHA512();

        var user = new AppUser
        {
            Username = registerDto.Username.ToLower(),
            PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
            PasswordSalt = hmac.Key
        };

        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return user;

    }

    private async Task<bool> UserExists(string username)
    {
        return await _context.Users.AnyAsync(x => x.Username == username.ToLower());
    }

}
