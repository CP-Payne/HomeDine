using HomeDine.Application.Common.Interfaces.Services;

namespace HomeDine.Infrastructure.Services
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime UtcNow => DateTime.UtcNow;
    }
}
