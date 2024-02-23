using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using commander.application.Interface.Authentication;
using commander.application.Interface.Services;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace commander.infrastructure.Authentication;

public class JwtTokenGenerator : IJwtTokenGenerator
{
  private readonly IDateTimeProvider _dateTimeProvider;
  private readonly JwtSettings _jwtSettings;
  public JwtTokenGenerator(IDateTimeProvider dateTimeProvider, IOptions<JwtSettings> jwtSettings)
  {
    _dateTimeProvider = dateTimeProvider;
    _jwtSettings = jwtSettings.Value;
  }
  public string GenerateToken(Guid userId, string firstName, string lastName, string role)
  {
    var signingCredentials = new SigningCredentials(
      new SymmetricSecurityKey(
        Encoding.UTF8.GetBytes(_jwtSettings.Secret)),
        SecurityAlgorithms.HmacSha256
      );

    var claims = new[]{
        new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        new Claim(JwtRegisteredClaimNames.GivenName, firstName),
        new Claim(JwtRegisteredClaimNames.FamilyName, lastName),
      };
    var securityToken = new JwtSecurityToken(
      issuer: _jwtSettings.Issuer,
      expires: _dateTimeProvider.UtcNow.AddMinutes(_jwtSettings.ExpireMinutes),
      audience: _jwtSettings.Audience,
      claims: claims,
      signingCredentials: signingCredentials
    );
    return new JwtSecurityTokenHandler().WriteToken(securityToken);
  }
}
