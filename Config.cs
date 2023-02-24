using Cronos;

namespace TestWorkerService;

public interface IScheduleConfig<T>
{
    CronExpression? CronExpression { get; set; }
    TimeZoneInfo TimeZoneInfo { get; set; }
}

public class ScheduleConfig<T> : IScheduleConfig<T>
{
    public CronExpression? CronExpression { get; set; }
    public TimeZoneInfo TimeZoneInfo { get; set; } = TimeZoneInfo.Local;
}