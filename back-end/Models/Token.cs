namespace Efficiency.Models;

public class Token
{
    public Token(string jwtTokenString)
    {
        this.JWTKey = jwtTokenString;
    }

    public string? JWTKey { get; set; }
}