using DesafioBTG.Domain.Interfaces.Services;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace DesafioBTG.Publisher
{
    public class JobExecutor
    {
        public readonly IOrderService _orderService;

        public JobExecutor()
        {
        }
        public JobExecutor(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task Executor()
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

                var ordersPublish = await _orderService.GetAllOrdersPublisher();

                foreach (var order in ordersPublish)
                {
                    string message = JsonSerializer.Serialize(order);

                    var body = Encoding.UTF8.GetBytes(message);

                    channel.BasicPublish(exchange: "",
                        routingKey: "orders-queue",
                        basicProperties: null,
                        body: body);

                    Console.WriteLine($"[x] Enviada: {message}");

                }
            }
        }
    }
}
