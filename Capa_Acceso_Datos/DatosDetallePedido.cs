using Capa_Entidades;
using System;
using System.Collections.Generic;

namespace Capa_Acceso_Datos
{
    public class DatosDetallePedido
    {
        private static DetallePedidoEntidad[] detalles = new DetallePedidoEntidad[500];
        private static int contador = 0;

        public bool Insertar(DetallePedidoEntidad detalle)
        {
            try
            {
                if (contador >= detalles.Length)
                    return false;

                detalles[contador] = detalle;
                contador++;
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DetallePedidoEntidad[] ObtenerPorPedido(int numeroPedido)
        {
            List<DetallePedidoEntidad> detallesPedido = new List<DetallePedidoEntidad>();

            for (int i = 0; i < contador; i++)
            {
                if (detalles[i].NumeroPedido == numeroPedido)
                {
                    detallesPedido.Add(detalles[i]);
                }
            }

            return detallesPedido.ToArray();
        }

        public bool ExisteArticuloEnPedido(int numeroPedido, int idArticulo)
        {
            for (int i = 0; i < contador; i++)
            {
                if (detalles[i].NumeroPedido == numeroPedido &&
                    detalles[i].Articulo.Id == idArticulo)
                    return true;
            }
            return false;
        }

        public bool EstaLleno()
        {
            return contador >= detalles.Length;
        }
    }
}



