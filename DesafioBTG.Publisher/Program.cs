using DesafioBTG.Publisher;

static class Program {

    static void Main(string[] args)
    {
        var executor = new JobExecutor();

        executor.Executor();

        //var factory = new ConnectionFactory()
        //{
        //    HostName = "localhost",
        //};
        //using (var connection = factory.CreateConnection())

        //using (var channel = connection.CreateModel())
        //{
        //    channel.QueueDeclare(queue: "orders-queue",
        //        durable: false,
        //        exclusive: false,
        //        autoDelete: false,
        //        arguments: null);

        //    var ordersPublish = await _orderService.GetAllOrdersPublisher();

        //   foreach(var order in ordersPublish)
        //   {
        //        string message = JsonSerializer.Serialize(order);

        //        var body = Encoding.UTF8.GetBytes(message);

        //        channel.BasicPublish(exchange: "",
        //            routingKey: "orders-queue",
        //            basicProperties: null,
        //            body: body);

        //        Console.WriteLine($"[x] Enviada: {message}");

        //    }

        //}
    }
}