using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using commander.application.Interface.Authentication;
using commander.application.Interface.Services;
using Microsoft.IdentityModel.Tokens;

namespace commander.infrastructure.Authentication;

public class JwtTokenGenerator : IJwtTokenGenerator
{
  private readonly IDateTimeProvider _dateTimeProvider;
  public JwtTokenGenerator(IDateTimeProvider dateTimeProvider)
  {
    _dateTimeProvider = dateTimeProvider;
  }
  public string GenerateToken(Guid userId, string firstName, string lastName, string role)
  {
    var signingCredentials = new SigningCredentials(
      new SymmetricSecurityKey(
        Encoding.UTF8.GetBytes("super-secret-secret")),
        SecurityAlgorithms.HmacSha256
      );

    var claims = new[]{
        new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        new Claim(JwtRegisteredClaimNames.GivenName, firstName),
        new Claim(JwtRegisteredClaimNames.FamilyName, lastName),
      };
    var securityToken = new JwtSecurityToken(
      issuer: "commander",
      expires: _dateTimeProvider.UtcNow.AddMinutes(60),
      claims: claims,
      signingCredentials: signingCredentials
    );
    return new JwtSecurityTokenHandler().WriteToken(securityToken);
  }
}
