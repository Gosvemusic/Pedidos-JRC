//* [UNED Perez Zeledon]
//* II Cuatrimestre 2025
//* Sistema de Gestion de Pedidos
//* [Javier Rojas Cordero]
//* Fecha: 27/05/2025

using Capa_Entidades; // Importa el espacio de nombres Capa_Entidades para usar las clases de entidad.
using System; // Importa el espacio de nombres System, que contiene funcionalidades basicas como el manejo de excepciones.

namespace Capa_Acceso_Datos // Define el espacio de nombres para la capa de acceso a datos de la aplicacion.
{
    public class DatosRepartidor // Declara la clase publica DatosRepartidor, que maneja las operaciones de datos para los repartidores.
    {
        private static RepartidorEntidad[] repartidores = new RepartidorEntidad[20]; // Declara un arreglo estatico de objetos RepartidorEntidad con capacidad para 20 repartidores.
        private static int contador = 0; // Declara un contador estatico para llevar la cuenta de cuantos repartidores hay en el arreglo.

        public bool Insertar(RepartidorEntidad repartidor) // Metodo publico para insertar un nuevo repartidor.
        {
            try // Inicia un bloque try para capturar posibles errores.
            {
                if (contador >= repartidores.Length) // Comprueba si el arreglo de repartidores esta lleno.
                    return false; // Si esta lleno, retorna false, indicando que no se puede insertar mas.

                if (ExisteIdentificacion(repartidor.Identificacion)) // Verifica si ya existe un repartidor con la misma identificacion.
                    return false; // Si la identificacion ya existe, retorna false.

                repartidores[contador] = repartidor; // Asigna el objeto repartidor al siguiente espacio disponible en el arreglo.
                contador++; // Incrementa el contador de repartidores.
                return true; // Retorna true si la insercion fue exitosa.
            }
            catch (Exception) // Captura cualquier excepcion que pueda ocurrir durante la operacion.
            {
                throw; // Relanza la excepcion, permitiendo que sea manejada en un nivel superior.
            }
        }

        public bool ExisteIdentificacion(int identificacion) // Metodo publico para verificar si una identificacion de repartidor ya existe.
        {
            for (int i = 0; i < contador; i++) // Itera sobre los repartidores existentes en el arreglo.
            {
                if (repartidores[i].Identificacion == identificacion) // Compara la identificacion del repartidor actual con la identificacion buscada.
                    return true; // Si encuentra una coincidencia, retorna true.
            }
            return false; // Si no encuentra la identificacion despues de revisar todos los repartidores, retorna false.
        }

        public RepartidorEntidad[] ObtenerTodos() // Metodo publico para obtener todos los repartidores almacenados.
        {
            RepartidorEntidad[] resultado = new RepartidorEntidad[contador]; // Crea un nuevo arreglo del tamano exacto de los repartidores actuales.
            Array.Copy(repartidores, resultado, contador); // Copia los repartidores desde el arreglo principal al nuevo arreglo.
            return resultado; // Retorna el arreglo con todos los repartidores.
        }

        public RepartidorEntidad[] ObtenerActivos() // Metodo publico para obtener solo los repartidores que estan activos.
        {
            int count = 0; // Inicializa un contador para los repartidores activos.
            for (int i = 0; i < contador; i++) // Itera sobre todos los repartidores.
            {
                if (repartidores[i].Activo) // Comprueba si el repartidor actual esta marcado como activo.
                    count++; // Si esta activo, incrementa el contador de activos.
            }

            RepartidorEntidad[] activos = new RepartidorEntidad[count]; // Crea un nuevo arreglo para almacenar solo los repartidores activos.
            int index = 0; // Inicializa un indice para el arreglo de repartidores activos.
            for (int i = 0; i < contador; i++) // Itera nuevamente sobre todos los repartidores.
            {
                if (repartidores[i].Activo) // Comprueba de nuevo si el repartidor esta activo.
                {
                    activos[index] = repartidores[i]; // Si esta activo, lo agrega al arreglo de repartidores activos.
                    index++; // Incrementa el indice para la siguiente posicion en el arreglo de activos.
                }
            }
            return activos; // Retorna el arreglo que contiene solo los repartidores activos.
        }

        public bool EstaLleno() // Metodo publico para verificar si el arreglo de repartidores esta lleno.
        {
            return contador >= repartidores.Length; // Retorna true si el numero de repartidores actuales es igual o excede la capacidad total del arreglo.
        }
    }
}
//Como referencias se utilizaron los libros (Como programar en C#, Harvey M. Deitel), (Guia de Estudio, Programacion Avanzada, Carlos H. Hernandez Alvarado, como tambien las tutorias del curso)
