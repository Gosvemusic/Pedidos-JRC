//* [UNED Perez Zeledon]
//* II Cuatrimestre 2025
//* Sistema de Gestion de Pedidos
//* [Javier Rojas Cordero]
//* Fecha: 27/05/2025

using Capa_Acceso_Datos; // Importa el espacio de nombres Capa_Acceso_Datos para acceder a las clases de acceso a datos.
using Capa_Entidades; // Importa el espacio de nombres Capa_Entidades para acceder a las clases de entidad.
using System; // Importa el espacio de nombres System para funcionalidades basicas como el manejo de excepciones.

namespace Capa_Log_Negocio // Define el espacio de nombres para la capa de logica de negocio.
{
    public class LogArticulo // Declara la clase publica LogArticulo, que maneja la logica de negocio relacionada con los articulos.
    {
        private DatosArticulo datos = new DatosArticulo(); // Crea una instancia privada de DatosArticulo para interactuar con la capa de acceso a datos.

        public string Insertar(ArticuloEntidad articulo) // Metodo publico para insertar un articulo, recibe un objeto ArticuloEntidad.
        {
            try // Inicia un bloque try para manejar posibles excepciones durante el proceso.
            {
                // Validaciones // Comentario que indica el inicio de las validaciones de negocio.
                if (articulo.Id <= 0) // Valida si el Id del articulo es menor o igual a cero.
                    return "El ID debe ser mayor a cero"; // Retorna un mensaje de error si la validacion falla.

                if (string.IsNullOrWhiteSpace(articulo.Nombre)) // Valida si el nombre del articulo es nulo, vacio o solo espacios en blanco.
                    return "El nombre es requerido"; // Retorna un mensaje de error si la validacion falla.

                if (articulo.TipoArticulo == null) // Valida si el tipo de articulo esta nulo.
                    return "Debe seleccionar un tipo de articulo"; // Retorna un mensaje de error si la validacion falla.

                if (articulo.Valor <= 0) // Valida si el valor del articulo es menor o igual a cero.
                    return "El valor debe ser mayor a cero"; // Retorna un mensaje de error si la validacion falla.

                if (articulo.Inventario < 0) // Valida si la cantidad en inventario es negativa.
                    return "El inventario no puede ser negativo"; // Retorna un mensaje de error si la validacion falla.

                if (datos.ExisteId(articulo.Id)) // Valida si ya existe un articulo con el mismo Id utilizando el metodo de la capa de datos.
                    return "Ya existe un articulo con ese ID"; // Retorna un mensaje de error si el Id ya existe.

                if (datos.EstaLleno()) // Valida si la capa de datos de articulos esta llena.
                    return "No se pueden ingresar mas registros"; // Retorna un mensaje de error si la capacidad esta agotada.

                bool resultado = datos.Insertar(articulo); // Llama al metodo Insertar de la capa de datos para guardar el articulo.
                return resultado ? "El registro se ha ingresado correctamente" : "Error al insertar el registro"; // Retorna un mensaje de exito o error basado en el resultado de la insercion.
            }
            catch (Exception ex) // Captura cualquier excepcion generica que pueda ocurrir.
            {
                return "Error: " + ex.Message; // Retorna un mensaje de error que incluye el mensaje de la excepcion.
            }
        }

        public ArticuloEntidad[] ObtenerTodos() // Metodo publico para obtener todos los articulos.
        {
            return datos.ObtenerTodos(); // Llama al metodo ObtenerTodos de la capa de datos y retorna su resultado.
        }

        public ArticuloEntidad[] ObtenerActivos() // Metodo publico para obtener solo los articulos activos.
        {
            return datos.ObtenerActivos(); // Llama al metodo ObtenerActivos de la capa de datos y retorna su resultado.
        }

        public void ActualizarInventario(int idArticulo, int cantidadRestar) // Metodo publico para actualizar el inventario de un articulo.
        {
            datos.ActualizarInventario(idArticulo, cantidadRestar); // Llama al metodo ActualizarInventario de la capa de datos para modificar la cantidad.
        }
    }
}
//Como referencias se utilizaron los libros (Como programar en C#, Harvey M. Deitel), (Guia de Estudio, Programacion Avanzada, Carlos H. Hernandez Alvarado, como tambien las tutorias del curso)

