using System;

namespace Capa_Entidades
{
    public class PedidoEntidad
    {
        public int NumeroPedido { get; set; }
        public DateTime FechaPedido { get; set; }
        public ClienteEntidad Cliente { get; set; }
        public RepartidorEntidad Repartidor { get; set; }
        public string Direccion { get; set; }
    }
}

