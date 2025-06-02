//* [UNED Perez Zeledon]
//* II Cuatrimestre 2025
//* Sistema de Gestion de Pedidos
//* [Javier Rojas Cordero]
//* Fecha: 27/05/2025

namespace Capa_Entidades // Define el espacio de nombres Capa_Entidades, donde se agrupan las clases que representan entidades del dominio.
{
    public class ArticuloEntidad // Declara la clase publica ArticuloEntidad, que representa la estructura de un articulo.
    {
        public int Id { get; set; } // Propiedad publica para el identificador unico del articulo. Permite obtener y establecer su valor.
        public string Nombre { get; set; } // Propiedad publica para el nombre del articulo.
        public TipoArticuloEntidad TipoArticulo { get; set; } // Propiedad publica que representa el tipo de articulo, usando una instancia de TipoArticuloEntidad.
        public double Valor { get; set; } // Propiedad publica para el valor o precio del articulo.
        public int Inventario { get; set; } // Propiedad publica para la cantidad de articulos en inventario.
        public bool Activo { get; set; } // Propiedad publica booleana que indica si el articulo esta activo o no.
    }
}
//Como referencias se utilizaron los libros (Como programar en C#, Harvey M. Deitel), (Guia de Estudio, Programacion Avanzada, Carlos H. Hernandez Alvarado, como tambien las tutorias del curso)
