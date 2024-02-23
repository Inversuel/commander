﻿namespace commander.application.Services;

public record AuthenticationResult(
  Guid Id,
  string FirstName,
  string LastName,
  string Email,
  string Token
);
