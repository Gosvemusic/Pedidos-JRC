//* [UNED Perez Zeledon]
//* II Cuatrimestre 2025
//* Sistema de Gestion de Pedidos
//* [Javier Rojas Cordero]
//* Fecha: 27/05/2025

using Capa_Acceso_Datos; // Importa el espacio de nombres Capa_Acceso_Datos para interactuar con las clases de acceso a datos.
using Capa_Entidades; // Importa el espacio de nombres Capa_Entidades para utilizar las clases de entidad (modelos de datos).
using System; // Importa el espacio de nombres System para acceder a funcionalidades basicas como DateTime y el manejo de excepciones.

namespace Capa_Log_Negocio // Define el espacio de nombres para la capa de logica de negocio de la aplicacion.
{
    public class LogPedido // Declara la clase publica LogPedido, que encapsula la logica de negocio relacionada con los pedidos.
    {
        private DatosPedido datosPedido = new DatosPedido(); // Crea una instancia privada de DatosPedido para manejar la persistencia de pedidos.
        private DatosDetallePedido datosDetalle = new DatosDetallePedido(); // Crea una instancia privada de DatosDetallePedido para manejar la persistencia de los detalles de pedido.
        private DatosArticulo datosArticulo = new DatosArticulo(); // Crea una instancia privada de DatosArticulo para manejar la persistencia de articulos y actualizar inventario.

        public string InsertarPedido(PedidoEntidad pedido) // Metodo publico para insertar un nuevo pedido, recibe un objeto PedidoEntidad.
        {
            try // Inicia un bloque try para manejar posibles excepciones durante la operacion.
            {
                // Validaciones // Comentario que indica el inicio de las reglas de negocio para la insercion de un pedido.
                if (pedido.NumeroPedido <= 0) // Valida que el numero de pedido sea un valor positivo.
                    return "El numero de pedido debe ser mayor a cero"; // Retorna un mensaje de error si la validacion falla.

                if (pedido.FechaPedido.Date < DateTime.Today) // Valida que la fecha del pedido no sea anterior a la fecha actual.
                    return "La fecha del pedido no puede ser anterior a hoy"; // Retorna un mensaje de error si la validacion falla.

                if (pedido.Cliente == null) // Valida que se haya seleccionado un cliente para el pedido.
                    return "Debe seleccionar un cliente"; // Retorna un mensaje de error si no hay cliente asociado.

                if (pedido.Repartidor == null) // Valida que se haya seleccionado un repartidor para el pedido.
                    return "Debe seleccionar un repartidor"; // Retorna un mensaje de error si no hay repartidor asociado.

                if (string.IsNullOrWhiteSpace(pedido.Direccion)) // Valida que la direccion de entrega no este vacia o solo con espacios en blanco.
                    return "La direccion es requerida"; // Retorna un mensaje de error si la direccion no es valida.

                if (datosPedido.ExisteNumeroPedido(pedido.NumeroPedido)) // Verifica si ya existe un pedido con el mismo numero.
                    return "Ya existe un pedido con ese numero"; // Retorna un mensaje de error si el numero de pedido ya esta en uso.

                if (datosPedido.EstaLleno()) // Verifica si la estructura de datos de pedidos esta llena.
                    return "No se pueden ingresar mas pedidos"; // Retorna un mensaje de error si la capacidad maxima de pedidos ha sido alcanzada.

                bool resultado = datosPedido.Insertar(pedido); // Llama al metodo de insercion en la capa de datos de pedidos.
                return resultado ? "Pedido registrado correctamente" : "Error al registrar el pedido"; // Retorna un mensaje de exito o error segun el resultado de la insercion.
            }
            catch (Exception ex) // Captura cualquier excepcion generica que pueda ocurrir durante el proceso.
            {
                return "Error: " + ex.Message; // Retorna un mensaje de error que incluye el detalle de la excepcion.
            }
        }

        public string InsertarDetalle(DetallePedidoEntidad detalle) // Metodo publico para insertar un detalle de pedido, recibe un objeto DetallePedidoEntidad.
        {
            try // Inicia un bloque try para manejar posibles excepciones.
            {
                // Validaciones // Comentario que indica el inicio de las reglas de negocio para la insercion de un detalle de pedido.
                if (detalle.Cantidad <= 0) // Valida que la cantidad del articulo en el detalle sea mayor a cero.
                    return "La cantidad debe ser mayor a cero"; // Retorna un mensaje de error si la cantidad no es valida.

                if (detalle.Cantidad > detalle.Articulo.Inventario) // Valida que la cantidad solicitada no exceda el inventario disponible del articulo.
                    return "La cantidad no puede ser mayor al inventario disponible"; // Retorna un mensaje de error si no hay suficiente inventario.

                if (datosDetalle.ExisteArticuloEnPedido(detalle.NumeroPedido, detalle.Articulo.Id)) // Verifica si el articulo ya esta registrado en el detalle de ese pedido.
                    return "Este articulo ya esta registrado en el pedido"; // Retorna un mensaje de error si el articulo ya existe en el pedido.

                if (datosDetalle.EstaLleno()) // Verifica si la estructura de datos de detalles de pedido esta llena.
                    return "No se pueden agregar mas detalles"; // Retorna un mensaje de error si la capacidad maxima de detalles ha sido alcanzada.

                // Calcular monto con 12% de envio // Comentario que explica el calculo del monto total del detalle.
                detalle.Monto = detalle.Articulo.Valor * detalle.Cantidad * 1.12; // Calcula el monto del detalle, aplicando un recargo del 12% (posiblemente por envio).

                bool resultado = datosDetalle.Insertar(detalle); // Llama al metodo de insercion en la capa de datos de detalles de pedido.

                if (resultado) // Si la insercion del detalle fue exitosa.
                {
                    // Actualizar inventario // Comentario que indica la actualizacion del inventario del articulo.
                    datosArticulo.ActualizarInventario(detalle.Articulo.Id, detalle.Cantidad); // Llama al metodo en la capa de datos de articulos para reducir el inventario.
                }

                return resultado ? "Articulo agregado al pedido" : "Error al agregar el articulo"; // Retorna un mensaje de exito o error segun el resultado de la insercion.
            }
            catch (Exception ex) // Captura cualquier excepcion generica que pueda ocurrir.
            {
                return "Error: " + ex.Message; // Retorna un mensaje de error que incluye el detalle de la excepcion.
            }
        }

        public PedidoEntidad[] ObtenerTodos() // Metodo publico para obtener todos los pedidos registrados.
        {
            return datosPedido.ObtenerTodos(); // Llama al metodo ObtenerTodos de la capa de datos de pedidos y retorna el arreglo resultante.
        }

        public DetallePedidoEntidad[] ObtenerDetallesPorPedido(int numeroPedido) // Metodo publico para obtener los detalles de un pedido especifico.
        {
            return datosDetalle.ObtenerPorPedido(numeroPedido); // Llama al metodo ObtenerPorPedido de la capa de datos de detalles y retorna el arreglo de detalles.
        }
    }
}
//Como referencias se utilizaron los libros (Como programar en C#, Harvey M. Deitel), (Guia de Estudio, Programacion Avanzada, Carlos H. Hernandez Alvarado, como tambien las tutorias del curso)

