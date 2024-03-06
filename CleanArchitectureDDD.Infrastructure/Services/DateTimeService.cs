
using CleanArchitectureDDD.Infrastructure.Interfaces;

namespace CleanArchitectureDDD.Infrastructure.Services
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime NowUtc => DateTime.UtcNow;
    }
}
