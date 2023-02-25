using DesafioBTG.Domain.Interfaces.Repositories;
using DesafioBTG.Domain.Interfaces.Services;
using DesafioBTG.Infra.Data.Repositories;
using DesafioBTG.Services.Services;
using DesafioBTG.Setup.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DesafioBTG.Setup
{
    public class Startup
    {
        public Startup(IConfiguration configuration) => Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services
                .AddMongoClientConfiguration(Configuration)
                .AddPaymentContext(Configuration);

           
        }
    }
}