using ErrorOr;
using HomeDine.Application.Authentication.Commands.Register;
using HomeDine.Application.Authentication.Common;
using HomeDine.Application.Authentication.Queries.Login;
using HomeDine.Contracts.Authentication;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using commonUtils = HomeDine.Domain.Common;

namespace HomeDine.Api.Controllers
{
    [Route("auth")]
    // [ErrorHandlingFilter]
    public class AuthenticationController : ApiController
    {
        private readonly ISender _mediator;

        public AuthenticationController(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync(RegisterRequest request)
        {
            var command = new RegisterCommand(
                request.FirstName,
                request.LastName,
                request.Email,
                request.Password
            );
            ErrorOr<AuthenticationResult> authResult = await _mediator.Send(command);
            // ErrorOr<AuthenticationResult> authResult = _authenticationCommandService.Register(
            //     request.FirstName,
            //     request.LastName,
            //     request.Email,
            //     request.Password
            // );

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
        public async Task<IActionResult> LoginAsync(LoginRequest request)
        {
            var query = new LoginQuery(request.Email, request.Password);
            var authResult = await _mediator.Send(query);
            if (
                authResult.IsError
                && authResult.FirstError == commonUtils.Errors.Authentication.InvalidCredentials
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
