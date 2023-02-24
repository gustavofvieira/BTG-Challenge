using DesafioBTG.Domain.Models;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

static class Program
{
    public static int Request { get; private set; }

    static void Main(string[] args)
    {
        var factory = new ConnectionFactory()
        {
            HostName = "localhost",
        };
        using (var connection = factory.CreateConnection())

        using (var channel = connection.CreateModel())
        {
            channel.QueueDeclare(queue: "requests-queue",
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null);

            var consumer = new EventingBasicConsumer(channel);


            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                var request = JsonSerializer.Deserialize<Request>(message);
                //Console.WriteLine($" [x] Recebida : {message}");
                Console.WriteLine($"Requests: {request.CodigoPedido} | {request.CodigoCliente} | {request.Itens}");
            };

            channel.BasicConsume(queue: "requests-queue", 
                autoAck: true,
                consumer: consumer);
        }
    }
}