﻿
using commander.application.Services;

namespace commander.application.Interface.Authentication;
public interface IAuthenticationService
{
  AuthenticationResult Login(string email, string password);
  AuthenticationResult Register(string firstName, string lastName, string email, string password);
}
