using HomeDine.Domain.Entities;

namespace HomeDine.Application.Common.Interfaces.Authentication
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(User user);
    }
}
