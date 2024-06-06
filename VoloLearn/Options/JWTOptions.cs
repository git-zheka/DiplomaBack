namespace VoloLearn.Options;

public class JWTOptions
{
    public string Issuer { get; set; }
    public string Audience { get; set; }
    public string SigningKey { get; set; }
    public int ExpirationSeconds { get; set; }
}