namespace commander.contracts.authentication;

public record RegisterRequest(
  string FirstName,
  string LastName,
  string Email,
  string Password
);
