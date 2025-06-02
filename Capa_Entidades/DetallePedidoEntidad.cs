//* [UNED Perez Zeledon]
//* II Cuatrimestre 2025
//* Sistema de Gestion de Pedidos
//* [Javier Rojas Cordero]
//* Fecha: 27/05/2025

namespace Capa_Entidades // Define el espacio de nombres Capa_Entidades, que agrupa las clases que representan objetos o "entidades" del sistema.
{
    public class DetallePedidoEntidad // Declara la clase publica DetallePedidoEntidad, que representa una linea de un pedido, detallando un articulo y su cantidad.
    {
        public int NumeroPedido { get; set; } // Propiedad publica para el numero del pedido al que pertenece este detalle. Permite obtener y establecer su valor.
        public ArticuloEntidad Articulo { get; set; } // Propiedad publica que representa el articulo especifico en este detalle del pedido, usando una instancia de ArticuloEntidad.
        public int Cantidad { get; set; } // Propiedad publica para la cantidad del articulo solicitado en este detalle.
        public double Monto { get; set; } // Propiedad publica para el monto total de este detalle del pedido (cantidad * valor del articulo).
    }
}
//Como referencias se utilizaron los libros (Como programar en C#, Harvey M. Deitel), (Guia de Estudio, Programacion Avanzada, Carlos H. Hernandez Alvarado, como tambien las tutorias del curso)
