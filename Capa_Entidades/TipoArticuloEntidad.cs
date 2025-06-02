//* [UNED Perez Zeledon]
//* II Cuatrimestre 2025
//* Sistema de Gestion de Pedidos
//* [Javier Rojas Cordero]
//* Fecha: 27/05/2025

namespace Capa_Entidades // Este espacio de nombres agrupa las clases que representan los objetos o "entidades" del sistema.
{
    public class TipoArticuloEntidad // Esta clase publica define la estructura de un tipo de articulo.
    {
        public int Id { get; set; } // La propiedad 'Id' es un entero que actua como identificador unico para el tipo de articulo. Permite obtener y establecer su valor.
        public string Nombre { get; set; } // La propiedad 'Nombre' es una cadena que almacena el nombre del tipo de articulo.
        public string Descripcion { get; set; } // La propiedad 'Descripcion' es una cadena que proporciona una explicacion mas detallada del tipo de articulo.
    }
}
//Como referencias se utilizaron los libros (Como programar en C#, Harvey M. Deitel), (Guia de Estudio, Programacion Avanzada, Carlos H. Hernandez Alvarado, como tambien las tutorias del curso)

