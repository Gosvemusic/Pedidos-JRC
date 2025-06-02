using Capa_Entidades;
using System;
using System.Collections.Generic;

namespace Capa_Acceso_Datos
{
    public class DatosDetallePedido // Define la clase DatosDetallePedido
    {
        private static DetallePedidoEntidad[] detalles = new DetallePedidoEntidad[500]; // Arreglo estatico para almacenar detalles de pedido
        private static int contador = 0; // Contador de detalles almacenados

        public bool Insertar(DetallePedidoEntidad detalle) // Metodo para insertar un detalle de pedido
        {
            try // Inicia el bloque try
            {
                if (contador >= detalles.Length) // Verifica si el arreglo esta lleno
                    return false; // Retorna falso si esta lleno

                detalles[contador] = detalle; // Asigna el detalle en la posicion actual
                contador++; // Incrementa el contador
                return true; // Retorna verdadero si se inserto correctamente
            }
            catch (Exception) // Captura cualquier excepcion
            {
                throw; // Relanza la excepcion
            }
        }

        public DetallePedidoEntidad[] ObtenerPorPedido(int numeroPedido) // Metodo para obtener los detalles de un pedido especifico
        {
            List<DetallePedidoEntidad> detallesPedido = new List<DetallePedidoEntidad>(); // Crea una lista para los detalles del pedido

            for (int i = 0; i < contador; i++) // Recorre los detalles almacenados
            {
                if (detalles[i].NumeroPedido == numeroPedido) // Verifica si el numero de pedido coincide
                {
                    detallesPedido.Add(detalles[i]); // Agrega el detalle a la lista
                }
            }

            return detallesPedido.ToArray(); // Retorna la lista como un arreglo
        }

        public bool ExisteArticuloEnPedido(int numeroPedido, int idArticulo) // Metodo para verificar si un articulo ya esta en un pedido
        {
            for (int i = 0; i < contador; i++) // Recorre los detalles almacenados
            {
                if (detalles[i].NumeroPedido == numeroPedido && // Verifica el numero de pedido
                    detalles[i].Articulo.Id == idArticulo) // Verifica el ID del articulo
                    return true; // Retorna verdadero si encuentra el articulo en el pedido
            }
            return false; // Retorna falso si no encuentra el articulo en el pedido
        }

        public bool EstaLleno() // Metodo para verificar si el arreglo esta lleno
        {
            return contador >= detalles.Length; // Retorna verdadero si el contador es mayor o igual al tamano del arreglo
        }
    }
}



