using Cronos;
using TestWorkerService;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        //services.AddHostedService<Worker>();
        services.AddCronJob<MyCronJob>(c =>
        {
            c.TimeZoneInfo = TimeZoneInfo.Local;
            c.CronExpression = CronExpression.Parse("*/2 * * * * *", CronFormat.IncludeSeconds);
        });
    })
    .Build();

host.Run();