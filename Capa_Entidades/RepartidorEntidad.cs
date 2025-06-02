//* [UNED Perez Zeledon]
//* II Cuatrimestre 2025
//* Sistema de Gestion de Pedidos
//* [Javier Rojas Cordero]
//* Fecha: 27/05/2025

using System; // Importa el espacio de nombres System para usar tipos de datos como DateTime.

namespace Capa_Entidades // Define el espacio de nombres Capa_Entidades, donde se agrupan las clases que representan los objetos o "entidades" del sistema.
{
    public class RepartidorEntidad : PersonaEntidad // Declara la clase publica RepartidorEntidad que hereda de PersonaEntidad. Esto significa que RepartidorEntidad tendra todas las propiedades de PersonaEntidad.
    {
        public DateTime FechaContratacion { get; set; } // Propiedad publica para almacenar la fecha de contratacion del repartidor.
    }
}
//Como referencias se utilizaron los libros (Como programar en C#, Harvey M. Deitel), (Guia de Estudio, Programacion Avanzada, Carlos H. Hernandez Alvarado, como tambien las tutorias del curso)
