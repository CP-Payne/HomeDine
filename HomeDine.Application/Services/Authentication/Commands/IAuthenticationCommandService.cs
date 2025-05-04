using ErrorOr;

namespace HomeDine.Application.Services.Authentication.Commands
{
    public interface IAuthenticationCommandService
    {
        ErrorOr<AuthenticationResult> Register(
            string firstName,
            string lastName,
            string email,
            string password
        );
    }
}
