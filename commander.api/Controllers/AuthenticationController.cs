using commander.application.Interface.Authentication;
using commander.contracts.authentication;
using Microsoft.AspNetCore.Mvc;

namespace commander.api.controllers;
[ApiController]
[Route("auth")]
public class AuthenticationController(IAuthenticationService authenticationService) : ControllerBase
{
  private readonly IAuthenticationService _authenticationService = authenticationService;

  [HttpPost("register")]
  public IActionResult Register(RegisterRequest request)
  {
    var result = _authenticationService.Register(request.FirstName, request.LastName, request.Email, request.Password);
    var AuthenticationResponse = new AuthenticationResponse
    (
      result.Id,
       result.FirstName,
       result.LastName,
       result.Email,
       result.Token
    );
    return Ok(AuthenticationResponse);
  }
  [HttpPost("login")]
  public IActionResult Login(LoginRequest request)
  {
    var result = _authenticationService.Login(request.Email, request.Password);
    var AuthenticationResponse = new AuthenticationResponse
    (
      result.Id,
       result.FirstName,
       result.LastName,
       result.Email,
       result.Token
    );
    return Ok(AuthenticationResponse);
  }

}