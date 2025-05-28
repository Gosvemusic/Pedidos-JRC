using Capa_Acceso_Datos;
using Capa_Entidades;
using System;

namespace Capa_Log_Negocio
{
    public class LogPedido
    {
        private DatosPedido datosPedido = new DatosPedido();
        private DatosDetallePedido datosDetalle = new DatosDetallePedido();
        private DatosArticulo datosArticulo = new DatosArticulo();

        public string InsertarPedido(PedidoEntidad pedido)
        {
            try
            {
                // Validaciones
                if (pedido.NumeroPedido <= 0)
                    return "El número de pedido debe ser mayor a cero";

                if (pedido.FechaPedido.Date < DateTime.Today)
                    return "La fecha del pedido no puede ser anterior a hoy";

                if (pedido.Cliente == null)
                    return "Debe seleccionar un cliente";

                if (pedido.Repartidor == null)
                    return "Debe seleccionar un repartidor";

                if (string.IsNullOrWhiteSpace(pedido.Direccion))
                    return "La dirección es requerida";

                if (datosPedido.ExisteNumeroPedido(pedido.NumeroPedido))
                    return "Ya existe un pedido con ese número";

                if (datosPedido.EstaLleno())
                    return "No se pueden ingresar más pedidos";

                bool resultado = datosPedido.Insertar(pedido);
                return resultado ? "Pedido registrado correctamente" : "Error al registrar el pedido";
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }

        public string InsertarDetalle(DetallePedidoEntidad detalle)
        {
            try
            {
                // Validaciones
                if (detalle.Cantidad <= 0)
                    return "La cantidad debe ser mayor a cero";

                if (detalle.Cantidad > detalle.Articulo.Inventario)
                    return "La cantidad no puede ser mayor al inventario disponible";

                if (datosDetalle.ExisteArticuloEnPedido(detalle.NumeroPedido, detalle.Articulo.Id))
                    return "Este artículo ya está registrado en el pedido";

                if (datosDetalle.EstaLleno())
                    return "No se pueden agregar más detalles";

                // Calcular monto con 12% de envío
                detalle.Monto = detalle.Articulo.Valor * detalle.Cantidad * 1.12;

                bool resultado = datosDetalle.Insertar(detalle);

                if (resultado)
                {
                    // Actualizar inventario
                    datosArticulo.ActualizarInventario(detalle.Articulo.Id, detalle.Cantidad);
                }

                return resultado ? "Artículo agregado al pedido" : "Error al agregar el artículo";
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }

        public PedidoEntidad[] ObtenerTodos()
        {
            return datosPedido.ObtenerTodos();
        }

        public DetallePedidoEntidad[] ObtenerDetallesPorPedido(int numeroPedido)
        {
            return datosDetalle.ObtenerPorPedido(numeroPedido);
        }
    }
}

