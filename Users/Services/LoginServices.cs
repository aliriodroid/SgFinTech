using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace User.Services;

public class LoginServices:ILoginService
{
   private readonly IConfiguration _config;
   public LoginServices(IConfiguration config)
   {
      _config = config;
   }

   public string GenerateToken(string userId,string email)
   {
      IEnumerable<System.Security.Claims.Claim> claims = new List<Claim>
      {
         new Claim(ClaimTypes.Email,email),
         new Claim(ClaimTypes.Role,"admin"),
         new Claim(ClaimTypes.NameIdentifier,userId),
      };
      var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("Jwt:Key").Value));
      var sigInCred = new SigningCredentials(securityKey,SecurityAlgorithms.HmacSha256Signature);
      
      var securityToken = new JwtSecurityToken(
         claims: claims,
         expires:DateTime.Now.AddMinutes(60),
         issuer : _config.GetSection("Jwt:Issuer").Value,
         audience : _config.GetSection("Jwt:Audience").Value,
         signingCredentials:sigInCred);
      
      string tokenString = new JwtSecurityTokenHandler().WriteToken(securityToken);
      return tokenString;
   }
}