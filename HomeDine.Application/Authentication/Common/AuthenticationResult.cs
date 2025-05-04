using HomeDine.Domain.Entities;

namespace HomeDine.Application.Authentication.Common
{
    public record AuthenticationResult(User user, string Token);
}
