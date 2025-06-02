//* [UNED Perez Zeledon]
//* II Cuatrimestre 2025
//* Sistema de Gestion de Pedidos
//* [Javier Rojas Cordero]
//* Fecha: 27/05/2025

using System; // Importa el espacio de nombres System para utilizar tipos de datos como DateTime.

namespace Capa_Entidades // Define el espacio de nombres donde se ubican las clases de entidad del sistema.
{
    public abstract class PersonaEntidad // Declara la clase abstracta PersonaEntidad. Al ser abstracta, no se pueden crear instancias directamente de ella, pero sirve como base para otras clases.
    {
        public int Identificacion { get; set; } // Propiedad publica para almacenar el numero de identificacion de la persona.
        public string Nombre { get; set; } // Propiedad publica para almacenar el primer nombre de la persona.
        public string PrimerApellido { get; set; } // Propiedad publica para almacenar el primer apellido de la persona.
        public string SegundoApellido { get; set; } // Propiedad publica para almacenar el segundo apellido de la persona.
        public DateTime FechaNacimiento { get; set; } // Propiedad publica para almacenar la fecha de nacimiento de la persona, usando el tipo DateTime.
        public bool Activo { get; set; } // Propiedad publica booleana que indica si la persona esta activa o no.
    }
}
//Como referencias se utilizaron los libros (Como programar en C#, Harvey M. Deitel), (Guia de Estudio, Programacion Avanzada, Carlos H. Hernandez Alvarado, como tambien las tutorias del curso)
