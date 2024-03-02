using Messaging.Runtime.Implementation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = Messaging.Host.Application.Start(args);
var monitor = host.Services.GetRequiredService<QueueMonitor>()!;

monitor.Start();
host.Run();