using RabbitMQ.Client;
using System.Text;

static class Program { 
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
    
            string message = "teste da aplicação";
            var body = Encoding.UTF8.GetBytes(message);
    
            channel.BasicPublish(exchange: "",
                routingKey: "requests-queue",
                basicProperties: null,
                body: body);
    
            Console.WriteLine($"[x] Enviada: {message}");
        }
        Console.ReadLine();
    }
}