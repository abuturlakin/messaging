using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = Messaging.Host.Application.Start(args);
var monitor = host.Services.GetRequiredService<App.QueueService.QueueMonitor>()!;

monitor.Start();
host.Run();