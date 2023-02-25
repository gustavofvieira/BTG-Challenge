using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;
using DesafioBTG.Domain.Models;

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
consumer.Received += (model, ea) =>
{
    try
    {
        var body = ea.Body.ToArray();
        var message = Encoding.UTF8.GetString(body);

        Console.WriteLine($" [x] Received {message}");

        var order = JsonSerializer.Deserialize<Order>(message);

        Console.WriteLine($"[x] Order Code: {order.CodeOrder} | CodeClient {order.CodeClient}");

        channel.BasicAck(ea.DeliveryTag, false);
    }
    catch(Exception ex)
    {
        //Logger
        channel.BasicNack(ea.DeliveryTag, false, true);
    }
    
};
channel.BasicConsume(queue: "orders-queue",
                     autoAck: false,
                     consumer: consumer);

Console.WriteLine(" Press [enter] to exit.");
Console.ReadLine();