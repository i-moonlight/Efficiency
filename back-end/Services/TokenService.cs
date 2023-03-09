using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Efficiency.Models;
using Microsoft.IdentityModel.Tokens;

namespace Efficiency.Services;

public class TokenService
{
    private readonly IConfiguration _configuration;

    public TokenService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public Token? Generate(User user)
    {
        Claim[] userRights = new Claim[] {
            new Claim("Username", user.UserName),
            new Claim("Id", user.Id.ToString())
        };

        var symmetricKey = new SymmetricSecurityKey(
            // Encrypted on https://www.online-toolz.com/tools/text-encryption-decryption.php
            Encoding.UTF8.GetBytes(this._configuration["Jwt:SecretKey"])
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