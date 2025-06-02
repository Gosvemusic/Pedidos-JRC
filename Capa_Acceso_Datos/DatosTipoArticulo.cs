//* [UNED Perez Zeledon]
//* II Cuatrimestre 2025
//* Sistema de Gestion de Pedidos
//* [Javier Rojas Cordero]
//* Fecha: 27/05/2025

using Capa_Entidades; // Importa el espacio de nombres Capa_Entidades para acceder a las definiciones de entidades.
using System; // Importa el espacio de nombres System, que provee funcionalidades basicas como el manejo de excepciones.

namespace Capa_Acceso_Datos // Define el espacio de nombres para la capa de acceso a datos de la aplicacion.
{
    public class DatosTipoArticulo // Declara la clase publica DatosTipoArticulo, encargada de gestionar los datos de tipos de articulo.
    {
        private static TipoArticuloEntidad[] tiposArticulo = new TipoArticuloEntidad[10]; // Declara un arreglo estatico de objetos TipoArticuloEntidad con una capacidad de 10.
        private static int contador = 0; // Declara un contador estatico para llevar la cuenta de cuantos tipos de articulo se han almacenado.

        public bool Insertar(TipoArticuloEntidad tipo) // Metodo publico para insertar un nuevo tipo de articulo en el arreglo.
        {
            try // Inicia un bloque try para manejar posibles excepciones durante la operacion.
            {
                if (contador >= tiposArticulo.Length) // Comprueba si el arreglo de tipos de articulo esta lleno.
                    return false; // Si esta lleno, retorna false, indicando que no se puede insertar mas.

                if (ExisteId(tipo.Id)) // Verifica si ya existe un tipo de articulo con el mismo Id.
                    return false; // Si el Id ya existe, retorna false.

                tiposArticulo[contador] = tipo; // Asigna el objeto 'tipo' a la siguiente posicion disponible en el arreglo.
                contador++; // Incrementa el contador de tipos de articulo.
                return true; // Retorna true si la insercion fue exitosa.
            }
            catch (Exception) // Captura cualquier excepcion generica que pueda ocurrir.
            {
                throw; // Relanza la excepcion, permitiendo que sea manejada por un nivel superior de la aplicacion.
            }
        }

        public bool ExisteId(int id) // Metodo publico para verificar si un Id de tipo de articulo ya existe.
        {
            for (int i = 0; i < contador; i++) // Itera a traves de los tipos de articulo existentes en el arreglo.
            {
                if (tiposArticulo[i].Id == id) // Compara el Id del tipo de articulo actual con el Id que se esta buscando.
                    return true; // Si encuentra una coincidencia, retorna true.
            }
            return false; // Si no se encuentra el Id despues de revisar todos los elementos, retorna false.
        }

        public TipoArticuloEntidad[] ObtenerTodos() // Metodo publico para obtener todos los tipos de articulo almacenados.
        {
            TipoArticuloEntidad[] resultado = new TipoArticuloEntidad[contador]; // Crea un nuevo arreglo de TipoArticuloEntidad con el tamano exacto de los elementos actuales.
            Array.Copy(tiposArticulo, resultado, contador); // Copia los elementos del arreglo 'tiposArticulo' al nuevo arreglo 'resultado'.
            return resultado; // Retorna el arreglo que contiene todos los tipos de articulo.
        }

        public bool EstaLleno() // Metodo publico para verificar si el arreglo de tipos de articulo esta lleno.
        {
            return contador >= tiposArticulo.Length; // Retorna true si el numero de elementos actuales es igual o excede la capacidad total del arreglo.
        }
    }
}
//Como referencias se utilizaron los libros (Como programar en C#, Harvey M. Deitel), (Guia de Estudio, Programacion Avanzada, Carlos H. Hernandez Alvarado, como tambien las tutorias del curso)


