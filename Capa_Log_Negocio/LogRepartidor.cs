//* [UNED Perez Zeledon]
//* II Cuatrimestre 2025
//* Sistema de Gestion de Pedidos
//* [Javier Rojas Cordero]
//* Fecha: 27/05/2025

using Capa_Acceso_Datos; // Importa el espacio de nombres Capa_Acceso_Datos para utilizar las clases de acceso a datos.
using Capa_Entidades; // Importa el espacio de nombres Capa_Entidades para utilizar las clases de entidad (modelos de datos).
using System; // Importa el espacio de nombres System para acceder a funcionalidades basicas como DateTime y el manejo de excepciones.

namespace Capa_Log_Negocio // Define el espacio de nombres para la capa de logica de negocio de la aplicacion.
{
    public class LogRepartidor // Declara la clase publica LogRepartidor, que encapsula la logica de negocio relacionada con los repartidores.
    {
        private DatosRepartidor datos = new DatosRepartidor(); // Crea una instancia privada de DatosRepartidor para interactuar con la capa de acceso a datos de repartidores.

        public string Insertar(RepartidorEntidad repartidor) // Metodo publico para insertar un nuevo repartidor, recibe un objeto RepartidorEntidad.
        {
            try // Inicia un bloque try para manejar posibles excepciones durante la operacion.
            {
                // Validaciones indica el inicio de las reglas de negocio para la insercion de un repartidor.
                if (repartidor.Identificacion <= 0) // Valida que la identificacion del repartidor sea un valor positivo.
                    return "La identificacion debe ser mayor a cero"; // Retorna un mensaje de error si la validacion falla.

                if (string.IsNullOrWhiteSpace(repartidor.Nombre)) // Valida que el nombre del repartidor no este nulo, vacio o solo con espacios en blanco.
                    return "El nombre es requerido"; // Retorna un mensaje de error si la validacion falla.

                if (string.IsNullOrWhiteSpace(repartidor.PrimerApellido)) // Valida que el primer apellido del repartidor no este nulo, vacio o solo con espacios en blanco.
                    return "El primer apellido es requerido"; // Retorna un mensaje de error si la validacion falla.

                if (string.IsNullOrWhiteSpace(repartidor.SegundoApellido)) // Valida que el segundo apellido del repartidor no este nulo, vacio o solo con espacios en blanco.
                    return "El segundo apellido es requerido"; // Retorna un mensaje de error si la validacion falla.

                // Validar mayor de edad // Comentario que indica la logica para verificar la edad del repartidor.
                int edad = DateTime.Today.Year - repartidor.FechaNacimiento.Year; // Calcula la edad inicial restando el ano de nacimiento del ano actual.
                if (repartidor.FechaNacimiento.Date > DateTime.Today.AddYears(-edad)) // Ajusta la edad si aun no ha cumplido anos en el presente ano.
                    edad--; // Decrementa la edad si la fecha de nacimiento es posterior al dia de hoy en el ano de nacimiento.

                if (edad < 18) // Valida que el repartidor sea mayor de 18 anos.
                    return "El repartidor debe ser mayor de edad"; // Retorna un mensaje de error si el repartidor es menor de edad.

                if (repartidor.FechaContratacion > DateTime.Today) // Valida que la fecha de contratacion no sea una fecha futura.
                    return "La fecha de contratacion no puede ser mayor a hoy"; // Retorna un mensaje de error si la fecha de contratacion no es valida.

                if (datos.ExisteIdentificacion(repartidor.Identificacion)) // Verifica si ya existe un repartidor con la misma identificacion en la capa de datos.
                    return "Ya existe un repartidor con esa identificacion"; // Retorna un mensaje de error si la identificacion ya esta en uso.

                if (datos.EstaLleno()) // Verifica si el almacenamiento de repartidores en la capa de datos esta lleno.
                    return "No se pueden ingresar mas registros"; // Retorna un mensaje de error si no hay mas espacio para nuevos registros.

                bool resultado = datos.Insertar(repartidor); // Llama al metodo de insercion en la capa de acceso a datos para guardar el repartidor.
                return resultado ? "El registro se ha ingresado correctamente" : "Error al insertar el registro"; // Retorna un mensaje de exito o error basado en el resultado de la insercion.
            }
            catch (Exception ex) // Captura cualquier excepcion generica que pueda ocurrir durante el proceso.
            {
                return "Error: " + ex.Message; // Retorna un mensaje de error que incluye el detalle de la excepcion.
            }
        }

        public RepartidorEntidad[] ObtenerTodos() // Metodo publico para obtener todos los repartidores registrados.
        {
            return datos.ObtenerTodos(); // Llama al metodo ObtenerTodos de la capa de datos y retorna el arreglo de repartidores.
        }

        public RepartidorEntidad[] ObtenerActivos() // Metodo publico para obtener solo los repartidores que estan activos.
        {
            return datos.ObtenerActivos(); // Llama al metodo ObtenerActivos de la capa de datos y retorna el arreglo de repartidores activos.
        }
    }
}
//Como referencias se utilizaron los libros (Como programar en C#, Harvey M. Deitel), (Guia de Estudio, Programacion Avanzada, Carlos H. Hernandez Alvarado, como tambien las tutorias del curso)
