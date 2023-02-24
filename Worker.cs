namespace TestWorkerService;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;

    public Worker(ILogger<Worker> logger)
    {
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("[Worker] Worker is starting at: {time}", DateTimeOffset.Now);
        stoppingToken.Register(() => _logger.LogInformation("Worker is stopping."));
        
        while (!stoppingToken.IsCancellationRequested)
        {
            _logger.LogInformation("[Worker] Worker running at: {time}", DateTimeOffset.Now);
            await Task.Delay(1000, stoppingToken);
        }
        
        _logger.LogInformation("[Worker] Worker has stopped");
    }
    
    
}