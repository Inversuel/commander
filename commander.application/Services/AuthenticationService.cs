using commander.application.Interface.Authentication;

namespace commander.application.Services;

public class AuthenticationService : IAuthenticationService
{
  private readonly IJwtTokenGenerator _jwtTokenGenerator;

  public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator)
  {
    _jwtTokenGenerator = jwtTokenGenerator;
  }
  public AuthenticationResult Login(string email, string password)
  {
    var token = _jwtTokenGenerator.GenerateToken(Guid.NewGuid(), "firstName", "lastName", "user");
    return new AuthenticationResult(Guid.NewGuid(), "John", "Doe", email, token);
  }

  public AuthenticationResult Register(string firstName, string lastName, string email, string password)
  {
    
    var userId = Guid.NewGuid();
    var token = _jwtTokenGenerator.GenerateToken(userId, firstName, lastName, "user");
    return new AuthenticationResult(Guid.NewGuid(), "John", "Doe", email, token);
  }
}
