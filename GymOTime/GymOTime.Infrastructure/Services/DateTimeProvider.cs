using GymOTime.Application.Common.Interfaces.Services;

namespace GymOTime.Infrastructure.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}