using HomeDine.Domain.Entities;

namespace HomeDine.Application.Services.Authentication
{
    public record AuthenticationResult(User user, string Token);
}
