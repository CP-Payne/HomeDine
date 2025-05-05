using HomeDine.Domain.Entities;

namespace HomeDine.Application.Authentication.Common
{
    public record AuthenticationResult(User User, string Token);
}
