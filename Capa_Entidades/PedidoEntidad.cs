//* [UNED Perez Zeledon]
//* II Cuatrimestre 2025
//* Sistema de Gestion de Pedidos
//* [Javier Rojas Cordero]
//* Fecha: 27/05/2025

using System; // Importa el espacio de nombres System, que provee funcionalidades basicas como el tipo de dato DateTime.

namespace Capa_Entidades // Define el espacio de nombres Capa_Entidades, donde se agrupan las clases que representan los objetos o "entidades" del sistema.
{
    public class PedidoEntidad // Declara la clase publica PedidoEntidad, que representa la estructura de un pedido en el sistema.
    {
        public int NumeroPedido { get; set; } // Propiedad publica para el numero unico del pedido. Permite obtener y establecer su valor.
        public DateTime FechaPedido { get; set; } // Propiedad publica para la fecha y hora en que se realizo el pedido, utilizando el tipo de dato DateTime.
        public ClienteEntidad Cliente { get; set; } // Propiedad publica que representa el cliente asociado a este pedido, utilizando una instancia de ClienteEntidad.
        public RepartidorEntidad Repartidor { get; set; } // Propiedad publica que representa el repartidor asignado a este pedido, utilizando una instancia de RepartidorEntidad.
        public string Direccion { get; set; } // Propiedad publica para la direccion de entrega del pedido, almacenada como una cadena de texto.
    }
}
//Como referencias se utilizaron los libros (Como programar en C#, Harvey M. Deitel), (Guia de Estudio, Programacion Avanzada, Carlos H. Hernandez Alvarado, como tambien las tutorias del curso)

