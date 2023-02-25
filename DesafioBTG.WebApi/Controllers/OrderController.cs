using DesafioBTG.Domain.Interfaces.Services;
using DesafioBTG.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using System;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DesafioBTG.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private ILogger<OrderController> _logger;
        private readonly IOrderService _orderService;

        public OrderController(ILogger<OrderController> logger, IOrderService orderService)
        {
            _logger = logger;
            _orderService = orderService;
        }

        [HttpPost]
        [Route("insert")]
        public IActionResult InsertOrder(Order order)
        {
            try
            {
                var factory = new ConnectionFactory { HostName = "localhost" };
                using (var connection = factory.CreateConnection())
                using (var channel = connection.CreateModel())
                {

                    channel.QueueDeclare(queue: "orders-queue",
                                         durable: false,
                                         exclusive: false,
                                         autoDelete: false,
                                         arguments: null);

                    string message = JsonSerializer.Serialize(order);
                    var body = Encoding.UTF8.GetBytes(message);

                    channel.BasicPublish(exchange: string.Empty,
                                         routingKey: "orders-queue",
                                         basicProperties: null,
                                         body: body);
          
                }
                return Accepted(order);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        [Route("totalOrder")]
        public async Task<IActionResult> totalByCodeOrder(int codeOrder) //a: valor total do pedido
        {
            var totalOrder = await _orderService.GetTotalByCodeOrder(codeOrder);
            return Ok(totalOrder);
        }

        [HttpGet]
        [Route("countOrders")]
        public async Task<IActionResult> countOrdersByClient(int codeClient) //b: Quantidade de Pedidos por Cliente

        {
            var countTotalOrders = await _orderService.GetTotalOrdersByCodeClient(codeClient);
            return Ok(countTotalOrders);
        }

        [HttpGet]
        [Route("ordersByClient")]
        public async Task<IActionResult> OrdersByClientList(int codeClient) //c: Lista de pedidos realizados por cliente
        {
            
            var totalOrders = await _orderService.OrdersByClientList(codeClient);
            return Ok(totalOrders);
        }


    }
}
