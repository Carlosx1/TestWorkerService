# TestWorkerService

Crea un cron job y una tarea programada que se ejecutan en segundo plano usando worker service

Al ser creado como worker service puede ser desplegado como un servicio de windows

Para probar los servicios por separados debe modificar el Program.cs de la siguiente manera
```csharp
/*
Tarea que se ejecutara cada segundo
Si se quiere quitar de la ejecucion se debe comentar la linea que lo instancia
*/ 
services.AddHostedService<Worker>();
/*
Cron Job que se ejecutara cada dos segundo
Si se quiere quitar de la ejecucion se debe comentar la linea que lo instancia
*/  
services.AddCronJob<MyCronJob>(c =>
{
    c.TimeZoneInfo = TimeZoneInfo.Local;
    c.CronExpression = CronExpression.Parse("*/2 * * * * *", CronFormat.IncludeSeconds);
});
```

Para crear el servicio de windows se puede seguir la siguiente documentacion

[Create and manage the Windows Service](https://learn.microsoft.com/en-us/aspnet/core/host-and-deploy/windows-service?view=aspnetcore-7.0&tabs=visual-studio#create-and-manage-the-windows-service)