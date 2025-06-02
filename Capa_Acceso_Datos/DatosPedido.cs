//* [UNED Perez Zeledon]
//* II Cuatrimestre 2025
//* Sistema de Gestion de Pedidos
//* [Javier Rojas Cordero]
//* Fecha: 27/05/2025

using Capa_Entidades; // Importa el espacio de nombres Capa_Entidades para usar las clases definidas alli.
using System; // Importa el espacio de nombres System que contiene clases fundamentales y tipos de datos basicos.

namespace Capa_Acceso_Datos // Declara el espacio de nombres para la capa de acceso a datos.
{
    public class DatosPedido // Declara la clase publica DatosPedido.
    {
        private static PedidoEntidad[] pedidos = new PedidoEntidad[40]; // Declara e inicializa un arreglo estatico de objetos PedidoEntidad con una capacidad de 40.
        private static int contador = 0; // Declara e inicializa un contador estatico para llevar el control de la cantidad de pedidos en el arreglo.

        public bool Insertar(PedidoEntidad pedido) // Metodo publico para insertar un nuevo pedido. Recibe un objeto PedidoEntidad.
        {
            try // Bloque try para manejar posibles excepciones.
            {
                if (contador >= pedidos.Length) // Comprueba si el arreglo de pedidos esta lleno.
                    return false; // Si esta lleno, retorna false indicando que no se pudo insertar.

                if (ExisteNumeroPedido(pedido.NumeroPedido)) // Comprueba si ya existe un pedido con el mismo numero.
                    return false; // Si ya existe, retorna false indicando que no se pudo insertar.

                pedidos[contador] = pedido; // Asigna el objeto pedido en la siguiente posicion disponible del arreglo.
                contador++; // Incrementa el contador de pedidos.
                return true; // Retorna true indicando que la insercion fue exitosa.
            }
            catch (Exception) // Captura cualquier excepcion que pueda ocurrir durante la ejecucion del try.
            {
                throw; // Relanza la excepcion para que sea manejada en un nivel superior.
            }
        }

        public bool ExisteNumeroPedido(int numeroPedido) // Metodo publico para verificar si un numero de pedido ya existe. Recibe un numero de pedido entero.
        {
            for (int i = 0; i < contador; i++) // Itera a traves de los pedidos existentes en el arreglo.
            {
                if (pedidos[i].NumeroPedido == numeroPedido) // Compara el numero de pedido actual con el numero de pedido buscado.
                    return true; // Si encuentra una coincidencia, retorna true.
            }
            return false; // Si no encuentra ninguna coincidencia despues de revisar todos los pedidos, retorna false.
        }

        public PedidoEntidad[] ObtenerTodos() // Metodo publico para obtener todos los pedidos almacenados.
        {
            PedidoEntidad[] resultado = new PedidoEntidad[contador]; // Crea un nuevo arreglo de PedidoEntidad con el tamano exacto de pedidos existentes.
            Array.Copy(pedidos, resultado, contador); // Copia los elementos del arreglo 'pedidos' al arreglo 'resultado'.
            return resultado; // Retorna el arreglo que contiene todos los pedidos.
        }

        public bool EstaLleno() // Metodo publico para verificar si el arreglo de pedidos esta lleno.
        {
            return contador >= pedidos.Length; // Retorna true si el contador es igual o mayor que la longitud del arreglo, indicando que esta lleno.
        }
    }
}
//Como referencias se utilizaron los libros (Como programar en C#, Harvey M. Deitel), (Guia de Estudio, Programacion Avanzada, Carlos H. Hernandez Alvarado, como tambien las tutorias del curso)



