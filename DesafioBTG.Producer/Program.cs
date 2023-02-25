using DesafioBTG.Worker.Producer;
using DesafioBTG.Setup;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        var startup = new Startup(hostContext.Configuration);
        startup.ConfigureServices(services);
        services.AddHostedService<WorkerExecutor>();
    })
    .Build();

host.Run();