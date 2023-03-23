using Blog.Data;
using Blog.Extensions;
using Blog.Models;
using Blog.Services;
using Blog.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SecureIdentity.Password;

namespace Blog.Controllers;

[ApiController]
public class AccountController : ControllerBase
{
    [HttpPost("v1/accounts")]
    public async Task<IActionResult> Post(
        [FromBody] RegisterViewModel model,
        [FromServices] BlogDataContext _context)
    {
        if (!ModelState.IsValid)
            return BadRequest(new ResultViewModel<string>(ModelState.GetErrors()));

        var user = new User
        {
            Name = model.Name,
            Email = model.Email,
            Slug = model.Email.Replace("@", "-").Replace(".", "-")
        };

        var password = PasswordGenerator.Generate(25);
        user.PasswordHash = PasswordHasher.Hash(password);
        try
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return Ok(new ResultViewModel<dynamic>(new
            {
                user = user.Email,
                password
            }));
        }
        catch (DbUpdateException)
        {
            return StatusCode(400, new ResultViewModel<string>("Email ja foi cadastrado"));
           
        }

    }

    [HttpPost("/v1/login")]
    public IActionResult Login(
        [FromServices] TokenService tokenService)
    {
        var token = tokenService.GenerateToken(user: null);

        return Ok(token);
    }




    //[Authorize(Roles = "user")]
    //[HttpGet("v1/user")]
    //public IActionResult GetUser() => Ok(User.Identity.Name);

    //[Authorize(Roles = "author")]
    //[HttpGet("v1/author")]
    //public IActionResult GetAuthor() => Ok(User.Identity.Name);

    //[Authorize(Roles = "admin")]
    //[HttpGet("v1/admin")]
    //public IActionResult GetAdmin() => Ok(User.Identity.Name);




    //private readonly TokenService _tokenService;
    //public AccountController(TokenService tokenService)
    //{
    //    _tokenService = tokenService;
    //}

    //[HttpPost("/v1/login")]
    //public IActionResult Login()
    //{
    //    var token = _tokenService.GenerateToken(user:null);

    //    return Ok(token);
    //}
}
