namespace commander.contracts.authentication;

public record LoginRequest(
  string Email,
  string Password
);
