//* [UNED Perez Zeledon]
//* II Cuatrimestre 2025
//* Sistema de Gestion de Pedidos
//* [Javier Rojas Cordero]
//* Fecha: 27/05/2025

namespace Capa_Entidades // Este es el espacio de nombres donde se agrupan las clases que representan los objetos o "entidades" de tu sistema.
{
    public class ClienteEntidad : PersonaEntidad // Aqui se define la clase publica ClienteEntidad. La notacion ": PersonaEntidad" significa que esta clase "hereda" de PersonaEntidad.
                                                 // Esto implica que ClienteEntidad obtendra automaticamente todas las propiedades y metodos definidos en PersonaEntidad.
    {
        // Hereda todas las propiedades de PersonaEntidad // Este comentario aclara que ClienteEntidad no necesita definir sus propias propiedades
        // si ya estan presentes en la clase base PersonaEntidad (como Identificacion, Nombre, Telefono, etc.).
    }
}
//Como referencias se utilizaron los libros (Como programar en C#, Harvey M. Deitel), (Guia de Estudio, Programacion Avanzada, Carlos H. Hernandez Alvarado, como tambien las tutorias del curso)
