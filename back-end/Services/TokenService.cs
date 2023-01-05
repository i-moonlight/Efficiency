using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Efficiency.Models;
using Microsoft.IdentityModel.Tokens;

namespace Efficiency.Services;

public class TokenService
{
    public Token? Generate(User user)
    {
        Claim[] userRights = new Claim[] {
            new Claim("Username", user.UserName),
            new Claim("Id", user.Id.ToString())
        };

        var symmetricKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes("xQgxoPGT6QeUHMOfgxQ9Nahvtlb6mKoGWP5toirbgUc=")
        );

        var credentials = new SigningCredentials(
            symmetricKey, 
            SecurityAlgorithms.HmacSha256
        );

        var jwtToken = new JwtSecurityToken(
            claims: userRights,
            signingCredentials: credentials,
            expires: DateTime.Now.AddHours(2)
        );

        var jwtTokenString = new JwtSecurityTokenHandler()
            .WriteToken(jwtToken);

        return new Token(jwtTokenString);
    }
}