//* [UNED Perez Zeledon]
//* II Cuatrimestre 2025
//* Sistema de Gestion de Pedidos
//* [Javier Rojas Cordero]
//* Fecha: 27/05/2025

using Capa_Acceso_Datos; // Importa el espacio de nombres Capa_Acceso_Datos para utilizar las clases de acceso a datos.
using Capa_Entidades; // Importa el espacio de nombres Capa_Entidades para utilizar las clases de entidad.
using System; // Importa el espacio de nombres System para funcionalidades basicas como el manejo de excepciones y tipos de fecha.

namespace Capa_Log_Negocio // Define el espacio de nombres para la capa de logica de negocio.
{
    public class LogCliente // Declara la clase publica LogCliente, que maneja la logica de negocio relacionada con los clientes.
    {
        private DatosCliente datos = new DatosCliente(); // Crea una instancia privada de DatosCliente para interactuar con la capa de acceso a datos de clientes.

        public string Insertar(ClienteEntidad cliente) // Metodo publico para insertar un cliente, recibe un objeto ClienteEntidad.
        {
            try // Inicia un bloque try para manejar posibles excepciones durante la ejecucion.
            {
                // Validaciones // Comentario que indica el inicio de las validaciones de negocio.
                if (cliente.Identificacion <= 0) // Valida si la identificacion del cliente es menor o igual a cero.
                    return "La identificacion debe ser mayor a cero"; // Retorna un mensaje de error si la validacion falla.

                if (string.IsNullOrWhiteSpace(cliente.Nombre)) // Valida si el nombre del cliente es nulo, vacio o solo espacios en blanco.
                    return "El nombre es requerido"; // Retorna un mensaje de error si la validacion falla.

                if (string.IsNullOrWhiteSpace(cliente.PrimerApellido)) // Valida si el primer apellido del cliente es nulo, vacio o solo espacios en blanco.
                    return "El primer apellido es requerido"; // Retorna un mensaje de error si la validacion falla.

                if (string.IsNullOrWhiteSpace(cliente.SegundoApellido)) // Valida si el segundo apellido del cliente es nulo, vacio o solo espacios en blanco.
                    return "El segundo apellido es requerido"; // Retorna un mensaje de error si la validacion falla.

                if (cliente.FechaNacimiento >= DateTime.Today) // Valida si la fecha de nacimiento es hoy o una fecha futura.
                    return "La fecha de nacimiento debe ser anterior a hoy"; // Retorna un mensaje de error si la validacion falla.

                if (datos.ExisteIdentificacion(cliente.Identificacion)) // Valida si ya existe un cliente con la misma identificacion en la capa de datos.
                    return "Ya existe un cliente con esa identificacion"; // Retorna un mensaje de error si la identificacion ya existe.

                if (datos.EstaLleno()) // Valida si el almacenamiento de clientes en la capa de datos esta lleno.
                    return "No se pueden ingresar mas registros"; // Retorna un mensaje de error si no hay mas espacio para nuevos registros.

                bool resultado = datos.Insertar(cliente); // Llama al metodo Insertar de la capa de acceso a datos para guardar el cliente.
                return resultado ? "El registro se ha ingresado correctamente" : "Error al insertar el registro"; // Retorna un mensaje de exito o error basado en el resultado de la insercion.
            }
            catch (Exception ex) // Captura cualquier excepcion generica que pueda ocurrir durante el proceso.
            {
                return "Error: " + ex.Message; // Retorna un mensaje de error que incluye el detalle de la excepcion.
            }
        }

        public ClienteEntidad[] ObtenerTodos() // Metodo publico para obtener todos los clientes.
        {
            return datos.ObtenerTodos(); // Llama al metodo ObtenerTodos de la capa de datos y retorna el arreglo de clientes.
        }

        public ClienteEntidad[] ObtenerActivos() // Metodo publico para obtener solo los clientes que estan activos.
        {
            return datos.ObtenerActivos(); // Llama al metodo ObtenerActivos de la capa de datos y retorna el arreglo de clientes activos.
        }
    }
}
//Como referencias se utilizaron los libros (Como programar en C#, Harvey M. Deitel), (Guia de Estudio, Programacion Avanzada, Carlos H. Hernandez Alvarado, como tambien las tutorias del curso)