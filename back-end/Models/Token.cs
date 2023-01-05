namespace Efficiency.Models;

public class Token
{
    public Token(string jwtTokenString)
    {
        this.Value = jwtTokenString;
    }

    public string? Value { get; set; }
}