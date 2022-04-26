using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace lda.Server.Controllers;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

[ApiController]
[Route("api/[controller]")]
public class JWTController : ControllerBase
{
    [HttpPost]
    [Authorize]
    public string Post()
    {
        var secretkey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("THIS IS THE SECRET KEY"));
        var credentials = new SigningCredentials(secretkey, SecurityAlgorithms.HmacSha256);
        
        var token = new JwtSecurityToken(issuer: "domain.com", audience: "domain.com", expires: DateTime.Now.AddMinutes(60), signingCredentials: credentials);
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}