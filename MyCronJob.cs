using Cronos;

namespace TestWorkerService;

public class MyCronJob : CronJobService
{
    private readonly ILogger<MyCronJob> _logger;
    
    public MyCronJob(IScheduleConfig<MyCronJob> config, ILogger<MyCronJob> logger) : base(config.CronExpression, config.TimeZoneInfo)
    {
        _logger = logger;
    }
    
    public override Task StartAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("[CronJob] CronJob starts");
        return base.StartAsync(cancellationToken);
    }
    
    public override Task DoWork(CancellationToken cancellationToken)
    {
        _logger.LogInformation("[CronJob] {Now} CronJob is working", DateTime.Now);
        return Task.CompletedTask;
    }
    
    public override Task StopAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("[CronJob] CronJob 3 is stopping");
        return base.StopAsync(cancellationToken);
    }
}