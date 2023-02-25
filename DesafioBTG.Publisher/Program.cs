using DesafioBTG.Publisher;
using DesafioBTG.Setup;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

class Program {

   
    static void Main(string[] args)
    {
        var builder = CreateHostBuilder();
                
        var app = builder.Build();

       var jobExecutor = new JobExecutor();
        jobExecutor.Executor().Wait();
        app.Run();
    }

    private static IHostBuilder CreateHostBuilder() =>
            Host.CreateDefaultBuilder()
                .ConfigureServices((hostContext, services) =>
                {
                    var startup = new Startup(hostContext.Configuration);

                    startup.ConfigureServices(services);
                });
}