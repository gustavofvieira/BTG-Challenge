using RabbitMQ.Client;
using System.Text;

static class Program { 
    static void Main(string[] args)
    {
        var factory = new ConnectionFactory()
        {
            HostName = "localhost",
            //Port = 15692,
            //UserName = "user",
            //Password = "password",
        };
        using (var connection = factory.CreateConnection())
    
        using (var channel = connection.CreateModel())
        {
            channel.QueueDeclare(queue: "requests-queue",
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null);
    
            string message = "{\r\n \"codigoPedido\": 1001,\r\n \"codigoCliente\":1,\r\n \"itens\": [\r\n {\r\n \"produto\": \"lápis\",\r\n \"quantidade\": 100,\r\n \"preco\": 1.10\r\n },\r\n {\r\n \"produto\": \"caderno\",\r\n \"quantidade\": 10,\r\n \"preco\": 1.00\r\n }\r\n ]\r\n}\r\n";
            var body = Encoding.UTF8.GetBytes(message);
    
            channel.BasicPublish(exchange: "",
                routingKey: "requests-queue",
                basicProperties: null,
                body: body);
    
            Console.WriteLine($"[x] Enviada: {message}");
        }
    }
}