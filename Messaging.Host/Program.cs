using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

using Messaging.Queue.Implementation;

var host = Messaging.Service.Application.Start(args);
var monitor = host.Services.GetRequiredService<QueueMonitor>()!;

monitor.Start();
host.Run();