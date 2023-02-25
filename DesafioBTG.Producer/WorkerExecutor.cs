using DesafioBTG.Domain.Interfaces.Services;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace DesafioBTG.Worker.Producer
{
    public class WorkerExecutor : IHostedService
    {
        public readonly ILogger<WorkerExecutor> _logger;
        public IOrderService _orderService;

        public WorkerExecutor(ILogger<WorkerExecutor> logger, IOrderService orderService)
        {
            _logger = logger;
            _orderService = orderService;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            var factory = new ConnectionFactory()
            {
                HostName = "localhost",
            };
            using (var connection = factory.CreateConnection())

            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "orders-queue",
                    durable: false,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null);

                var ordersPublish = _orderService.GetAllOrdersPublisher();

                foreach (var order in ordersPublish)
                {
                    string message = JsonSerializer.Serialize(order);

                    var body = Encoding.UTF8.GetBytes(message);

                    channel.BasicPublish(exchange: "",
                        routingKey: "orders-queue",
                        basicProperties: null,
                        body: body);

                    _logger.LogInformation("[x] Enviada: {message}", message);
                    Console.ReadLine();

                }
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogCritical("Service stopped");
            return Task.CompletedTask;
        }
    }
}
