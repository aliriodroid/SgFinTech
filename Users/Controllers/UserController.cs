using System.Security.Claims;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using User.Data.Repositories;
using User.Services;


namespace User.Controllers;


[ApiController]
[Route("[controller]")]
public class UserController:ControllerBase
{
    
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly ILoginService _loginServices;

    public UserController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, ILoginService loginServices)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _loginServices = loginServices;
    }
    
    [HttpPost]
    [Route("/register/")]
    public async Task<IActionResult> Register(string email, string password)
    {
        var user = new IdentityUser { UserName = email, Email = email };
        var result = await _userManager.CreateAsync(user, password);
        if (result.Succeeded)
        {
            await _signInManager.SignInAsync(user, isPersistent: false);
            return Ok();
        }
        return BadRequest(result.Errors);
    }
    
    [HttpPost("login")]
    public async Task<IActionResult> Login(string email, string password)
    {
        var result = await _signInManager.PasswordSignInAsync(email, password, isPersistent: false, lockoutOnFailure: false);
        var userCandidate = await _signInManager.UserManager.FindByEmailAsync(email);
        if (result.Succeeded)
        {
            var tokenString = _loginServices.GenerateToken(userCandidate.Id,email);
            return Ok(tokenString);
        }

        return Unauthorized("Invalid login attempt.");
    }

}