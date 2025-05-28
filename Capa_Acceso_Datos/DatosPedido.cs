using Capa_Entidades;
using System;

namespace Capa_Acceso_Datos
{
    public class DatosPedido
    {
        private static PedidoEntidad[] pedidos = new PedidoEntidad[40];
        private static int contador = 0;

        public bool Insertar(PedidoEntidad pedido)
        {
            try
            {
                if (contador >= pedidos.Length)
                    return false;

                if (ExisteNumeroPedido(pedido.NumeroPedido))
                    return false;

                pedidos[contador] = pedido;
                contador++;
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool ExisteNumeroPedido(int numeroPedido)
        {
            for (int i = 0; i < contador; i++)
            {
                if (pedidos[i].NumeroPedido == numeroPedido)
                    return true;
            }
            return false;
        }

        public PedidoEntidad[] ObtenerTodos()
        {
            PedidoEntidad[] resultado = new PedidoEntidad[contador];
            Array.Copy(pedidos, resultado, contador);
            return resultado;
        }

        public bool EstaLleno()
        {
            return contador >= pedidos.Length;
        }
    }
}



