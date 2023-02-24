using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

static class Program
{
    static void Main(string[] args)
    {
        var factory = new ConnectionFactory()
        {
            HostName = "localhost",
            //Port = 8080,
            Port = 15672,
            UserName = "user",
            Password = "password",
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
                Console.WriteLine($" [x] Recebida : {message}");
            };

            channel.BasicConsume(queue: "requests-queue", 
                autoAck: true,
                consumer: consumer);
        }
        Console.ReadLine();
    }
}