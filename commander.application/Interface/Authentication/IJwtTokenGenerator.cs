namespace commander.application.Interface.Authentication
{
  public interface IJwtTokenGenerator
  {
    string GenerateToken(Guid userId, string firstName, string lastName, string role);
  }
}