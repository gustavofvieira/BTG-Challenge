namespace DesafioBTG.Domain.Models
{
    public class Order
    {
        public int CodigoPedido { get; set; }
        public int CodigoCliente { get; set; }
        public List<Item> Itens { get; set; }

    }
}
