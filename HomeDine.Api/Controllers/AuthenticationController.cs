using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ErrorOr;
using FluentResults;
using HomeDine.Application.Services.Authentication;
using HomeDine.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using common = HomeDine.Domain.Common;

namespace HomeDine.Api.Controllers
{
    [Route("auth")]
    // [ErrorHandlingFilter]
    public class AuthenticationController : ApiController
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterRequest request)
        {
            ErrorOr<AuthenticationResult> authResult = _authenticationService.Register(
                request.FirstName,
                request.LastName,
                request.Email,
                request.Password
            );

            return authResult.Match(
                authResult => Ok(MapAuthResult(authResult)),
                errors => Problem(errors)
            );
        }

        private static AuthenticationResponse MapAuthResult(AuthenticationResult authResult)
        {
            return new AuthenticationResponse(
                authResult.user.Id,
                authResult.user.FirstName,
                authResult.user.LastName,
                authResult.user.Email,
                authResult.Token
            );
        }

        [HttpPost("login")]
        public IActionResult Login(LoginRequest request)
        {
            var authResult = _authenticationService.Login(request.Email, request.Password);
            if (
                authResult.IsError
                && authResult.FirstError == common.Errors.Authentication.InvalidCredentials
            )
            {
                return Problem(
                    statusCode: StatusCodes.Status401Unauthorized,
                    title: authResult.FirstError.Description
                );
            }

            return authResult.Match(
                authResult => Ok(MapAuthResult(authResult)),
                errors => Problem(errors)
            );
        }
    }
}
