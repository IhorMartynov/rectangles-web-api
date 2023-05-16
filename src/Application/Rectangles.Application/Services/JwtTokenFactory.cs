using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Rectangles.Application.Contracts.Services;

namespace Rectangles.Application.Services;

internal sealed class JwtTokenFactory : IJwtTokenFactory
{
    private readonly int _expirationMinutes;
    private readonly string _audience;
    private readonly string _issuer;
    private readonly string _subject;
    private readonly string _issuerSigningKey;

    public JwtTokenFactory(int expirationMinutes,
        string audience,
        string issuer,
        string issuerSigningKey,
        string subject)
    {
        _expirationMinutes = expirationMinutes;
        _audience = audience;
        _issuer = issuer;
        _issuerSigningKey = issuerSigningKey;
        _subject = subject;
    }

    /// <inheritdoc />
    public string Create(string userName, string email, string id, params string[] roles)
    {
        var expiration = DateTime.UtcNow.AddMinutes(_expirationMinutes);

        var token = CreateJwtToken(
            CreateClaims(userName, email, id, roles),
            CreateSigningCredentials(),
            expiration
        );

        var tokenHandler = new JwtSecurityTokenHandler();

        return tokenHandler.WriteToken(token);
    }

    private JwtSecurityToken CreateJwtToken(Claim[] claims, SigningCredentials credentials, DateTime expiration) =>
        new(
            _issuer,
            _audience,
            claims,
            expires: expiration,
            signingCredentials: credentials
        );

    private Claim[] CreateClaims(string userName, string email, string id, params string[] roles) =>
        new[] {
            new Claim(JwtRegisteredClaimNames.Sub, _subject),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString(CultureInfo.InvariantCulture)),
            new Claim(ClaimTypes.NameIdentifier, id),
            new Claim(ClaimTypes.Name, userName),
            new Claim(ClaimTypes.Email, email),
            new Claim(ClaimTypes.Role, string.Join(",", roles))
        };

    private SigningCredentials CreateSigningCredentials() =>
        new(
            new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_issuerSigningKey)
            ),
            SecurityAlgorithms.HmacSha256
        );
}