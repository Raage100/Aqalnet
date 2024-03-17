using Aqalnet.Application.Abstractions.Clock;

namespace Aqalnet.Infrastructure.Clock;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}
