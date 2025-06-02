//* [UNED Perez Zeledon]
//* II Cuatrimestre 2025
//* Sistema de Gestion de Pedidos
//* [Javier Rojas Cordero]
//* Fecha: 27/05/2025

using Capa_Acceso_Datos; // Importa el espacio de nombres Capa_Acceso_Datos para utilizar las clases de acceso a datos.
using Capa_Entidades; // Importa el espacio de nombres Capa_Entidades para utilizar las clases de entidad (modelos de datos).
using System; // Importa el espacio de nombres System para funcionalidades basicas como el manejo de excepciones.

namespace Capa_Log_Negocio // Define el espacio de nombres para la capa de logica de negocio de la aplicacion.
{
    public class LogTipoArticulo // Declara la clase publica LogTipoArticulo, que encapsula la logica de negocio relacionada con los tipos de articulo.
    {
        private DatosTipoArticulo datos = new DatosTipoArticulo(); // Crea una instancia privada de DatosTipoArticulo para interactuar con la capa de acceso a datos.

        public string Insertar(TipoArticuloEntidad tipo) // Metodo publico para insertar un nuevo tipo de articulo. Recibe un objeto TipoArticuloEntidad.
        {
            try // Inicia un bloque try para manejar posibles excepciones durante la operacion.
            {
                // Validaciones // Comentario que indica el inicio de las reglas de negocio para la insercion de un tipo de articulo.
                if (tipo.Id <= 0) // Valida que el Id del tipo de articulo sea mayor a cero.
                    return "El ID debe ser mayor a cero"; // Retorna un mensaje de error si la validacion falla.

                if (string.IsNullOrWhiteSpace(tipo.Nombre)) // Valida que el nombre del tipo de articulo no este nulo, vacio o solo con espacios en blanco.
                    return "El nombre es requerido"; // Retorna un mensaje de error si la validacion falla.

                if (string.IsNullOrWhiteSpace(tipo.Descripcion)) // Valida que la descripcion del tipo de articulo no este nula, vacia o solo con espacios en blanco.
                    return "La descripcion es requerida"; // Retorna un mensaje de error si la validacion falla.

                if (datos.ExisteId(tipo.Id)) // Verifica si ya existe un tipo de articulo con el mismo Id en la capa de datos.
                    return "Ya existe un tipo de articulo con ese ID"; // Retorna un mensaje de error si el Id ya esta en uso.

                if (datos.EstaLleno()) // Verifica si el almacenamiento de tipos de articulo en la capa de datos esta lleno.
                    return "No se pueden ingresar mas registros"; // Retorna un mensaje de error si no hay mas espacio para nuevos registros.

                bool resultado = datos.Insertar(tipo); // Llama al metodo de insercion en la capa de acceso a datos para guardar el tipo de articulo.
                return resultado ? "El registro se ha ingresado correctamente" : "Error al insertar el registro"; // Retorna un mensaje de exito o error basado en el resultado de la insercion.
            }
            catch (Exception ex) // Captura cualquier excepcion generica que pueda ocurrir durante el proceso.
            {
                return "Error: " + ex.Message; // Retorna un mensaje de error que incluye el detalle de la excepcion.
            }
        }

        public TipoArticuloEntidad[] ObtenerTodos() // Metodo publico para obtener todos los tipos de articulo registrados.
        {
            return datos.ObtenerTodos(); // Llama al metodo ObtenerTodos de la capa de datos y retorna el arreglo de tipos de articulo.
        }
    }
}
//Como referencias se utilizaron los libros (Como programar en C#, Harvey M. Deitel), (Guia de Estudio, Programacion Avanzada, Carlos H. Hernandez Alvarado, como tambien las tutorias del curso)
