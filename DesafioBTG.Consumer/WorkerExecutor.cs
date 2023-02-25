using DesafioBTG.Domain.Interfaces.Services;
using DesafioBTG.Domain.Models;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

namespace DesafioBTG.Worker.Consumer
{
    public class WorkerExecutor : IHostedService
    {
        public readonly ILogger<WorkerExecutor> _logger;
        public readonly IOrderService _orderService;

        public WorkerExecutor(ILogger<WorkerExecutor> logger, IOrderService orderService)
        {
            _logger = logger;
            _orderService = orderService;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            var factory = new ConnectionFactory { HostName = "localhost" };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.QueueDeclare(queue: "orders-queue",
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            Console.WriteLine(" [*] Waiting for messages.");

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += async (model, ea) =>
            {
                try
                {
                    var body = ea.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);

                    _logger.LogInformation(" [x] Received: {message}", message);

                    Order order = JsonSerializer.Deserialize<Order>(message)!;

                    _logger.LogInformation("[x] Order Code: {CodeOrder} | CodeClient {CodeClient}", order?.CodeOrder, order?.CodeClient);

                    channel.BasicAck(ea.DeliveryTag, false);

                   await _orderService.AddOrder(order!);
                }
                catch (Exception ex)
                {
                    _logger.LogError("Exception: ",ex.Message);
                    channel.BasicNack(ea.DeliveryTag, false, true);
                }

            };
            channel.BasicConsume(queue: "orders-queue",
                                 autoAck: false,
                                 consumer: consumer);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogCritical("Service stopped");
            return Task.CompletedTask;
        }
    }
}
