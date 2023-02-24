//using DesafioBTG.Domain.Models;
//using RabbitMQ.Client;
//using RabbitMQ.Client.Events;
//using System.Text;
//using System.Text.Json;

//static class Program
//{
//    static void Main(string[] args)
//    {
//        var factory = new ConnectionFactory()
//        {
//            HostName = "localhost",
//        };
//        using (var connection = factory.CreateConnection())

//        using (var channel = connection.CreateModel())
//        {
//            channel.QueueDeclare(queue: "orders-queue",
//                durable: false,
//                exclusive: false,
//                autoDelete: false,
//                arguments: null);

//            var consumer = new EventingBasicConsumer(channel);


//            consumer.Received += (model, ea) =>
//            {
//                var body = ea.Body.ToArray();
//                var message = Encoding.UTF8.GetString(body);
//                var request = JsonSerializer.Deserialize<Order>(message);
//                //Console.WriteLine($" [x] Recebida : {message}");
//                Console.WriteLine($"Orders: {request.CodigoPedido} | {request.CodigoCliente} | {request.Itens}");
//            };

//            channel.BasicConsume(queue: "orders-queue",
//                autoAck: true,
//                consumer: consumer);
//        }
//    }
//}