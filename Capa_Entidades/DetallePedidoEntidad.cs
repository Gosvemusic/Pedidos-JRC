namespace Capa_Entidades
{
    public class DetallePedidoEntidad
    {
        public int NumeroPedido { get; set; }
        public ArticuloEntidad Articulo { get; set; }
        public int Cantidad { get; set; }
        public double Monto { get; set; }
    }
}
