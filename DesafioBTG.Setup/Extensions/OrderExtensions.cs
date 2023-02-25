using DesafioBTG.Infra.Data.Context;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace DesafioBTG.Setup.Extensions
{
    public static class OrderExtensions
    {
        public static IServiceCollection AddOrderContext(this IServiceCollection services, IConfiguration config)
        {
            return services
                 .AddScoped(sp =>
                    new OrderContext(
                        //sp.GetRequiredService<MongoClient>().GetDatabase(config.GetConnectionString("DesafioBTGDatabase"))
                        sp.GetRequiredService<MongoClient>().GetDatabase("DesafioBTG")
                    )
                );
        }
    }
}
