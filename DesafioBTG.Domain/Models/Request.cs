namespace DesafioBTG.Domain.Models
{
    public class Request
    {
        public int CodigoPedido { get; set; }
        public int CodigoCliente { get; set; }
        public List<Itens> Itens { get; set; }

    }
}
