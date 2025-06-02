//* [UNED Perez Zeledon]
//* II Cuatrimestre 2025
//* Sistema de Gestion de Pedidos
//* [Javier Rojas Cordero]
//* Fecha: 27/05/2025

using System; // Permite usar funcionalidades basicas del sistema, como tipos de datos y excepciones.
using System.Collections.Generic; // Permite el uso de colecciones genericas como List<T>.
using System.ComponentModel; // Proporciona clases para implementar componentes y controles.
using System.Data; // Permite el manejo de datos y conjuntos de datos.
using System.Drawing; // Proporciona acceso a funcionalidades graficas basicas.
using System.Linq; // Habilita consultas LINQ para colecciones de objetos.
using System.Text; // Permite el manejo de codificacion de caracteres.
using System.Threading.Tasks; // Permite el uso de programacion asincrona.
using System.Windows.Forms; // Proporciona clases para crear aplicaciones de Windows Forms.
using Capa_Entidades; // Importa las clases de la capa de entidades del proyecto.
using Capa_Log_Negocio; // Importa las clases de la capa de logica de negocio del proyecto.

namespace Capa_Interfaz // Define el espacio de nombres para la capa de interfaz de usuario.
{
    public partial class FrmRegistroPedido : Form // Declara la clase FrmRegistroPedido, que hereda de Form.
    {
        // Se declaran instancias de las clases de logica de negocio para interactuar con las entidades.
        private LogPedido logicaPedido = new LogPedido();
        private LogCliente logicaCliente = new LogCliente();
        private LogRepartidor logicaRepartidor = new LogRepartidor();
        private LogArticulo logicaArticulo = new LogArticulo();
        // Lista temporal para almacenar los detalles del pedido antes de guardarlos.
        private List<DetallePedidoEntidad> detallesTemporales = new List<DetallePedidoEntidad>();
        private bool pedidoGuardado = false; // Bandera para controlar si el encabezado del pedido ya fue guardado.

        public FrmRegistroPedido() // Constructor de la clase FrmRegistroPedido.
        {
            InitializeComponent(); // Inicializa los componentes visuales del formulario.
            ConfigurarFormulario(); // Llama a un metodo para configurar el formulario.
            CargarCombos(); // Llama a un metodo para cargar los ComboBox.
            ConfigurarDataGridView(); // Llama a un metodo para configurar el DataGridView.
        }

        private void ConfigurarFormulario() // Metodo para configurar la apariencia y estado inicial del formulario.
        {
            // Configurar DateTimePicker para mostrar solo fecha.
            dtpFechaPedido.Format = DateTimePickerFormat.Short;
            dtpFechaPedido.Value = DateTime.Today; // Establece la fecha actual.

            // Habilitar todo al inicio.
            gbEncabezado.Enabled = true; // Habilita el GroupBox del encabezado.
            gbDetalle.Enabled = true; // Habilita el GroupBox del detalle.

            // Configurar el boton.
            btnRegistrarPedido.Text = "Guardar Pedido"; // Cambia el texto del boton.

            // Limpiar placeholders (campos de texto).
            txtNumeroPedido.Text = ""; // Limpia el campo de texto del numero de pedido.
            txtDireccion.Text = ""; // Limpia el campo de texto de la direccion.
            txtCantidad.Text = ""; // Limpia el campo de texto de la cantidad.
        }

        private void ConfigurarDataGridView() // Metodo para configurar las columnas del DataGridView.
        {
            dgvDetalle.Columns.Clear(); // Limpia cualquier columna existente en el DataGridView.
            dgvDetalle.Columns.Add("NumeroPedido", "Numero Pedido"); // Agrega la columna 'Numero Pedido'.
            dgvDetalle.Columns.Add("IdArticulo", "ID Articulo"); // Agrega la columna 'ID Articulo'.
            dgvDetalle.Columns.Add("NombreArticulo", "Nombre Articulo"); // Agrega la columna 'Nombre Articulo'.
            dgvDetalle.Columns.Add("TipoArticulo", "Tipo Articulo"); // Agrega la columna 'Tipo Articulo'.
            dgvDetalle.Columns.Add("Cantidad", "Cantidad"); // Agrega la columna 'Cantidad'.
            dgvDetalle.Columns.Add("Monto", "Monto"); // Agrega la columna 'Monto'.

            dgvDetalle.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Ajusta el tamaño de las columnas para llenar el control.
            dgvDetalle.AllowUserToAddRows = false; // Deshabilita la opcion de agregar filas directamente en el DataGridView.
        }

        private class ComboBoxItem // Clase anidada para representar elementos en un ComboBox.
        {
            public object Value { get; set; } // Propiedad para almacenar el valor real del item (objeto).
            public string Display { get; set; } // Propiedad para almacenar el texto a mostrar.

            public override string ToString() // Sobrescribe el metodo ToString para mostrar el texto.
            {
                return Display; // Retorna el texto a mostrar.
            }
        }

        private void CargarCombos() // Metodo para cargar los ComboBox con datos.
        {
            try // Bloque try-catch para manejar posibles excepciones.
            {
                // Cargar clientes activos.
                var clientes = logicaCliente.ObtenerActivos(); // Obtiene la lista de clientes activos.
                cboCliente.Items.Clear(); // Limpia los items existentes en el ComboBox de clientes.
                cboCliente.Items.Add("-- Seleccione Cliente --"); // Agrega un item por defecto.

                foreach (var cliente in clientes) // Itera sobre cada cliente.
                {
                    // Crea el texto a mostrar en el ComboBox.
                    string displayText = $"{cliente.Nombre} {cliente.PrimerApellido} {cliente.SegundoApellido}";
                    // Agrega un nuevo ComboBoxItem con el cliente y el texto.
                    cboCliente.Items.Add(new ComboBoxItem { Value = cliente, Display = displayText });
                }
                cboCliente.SelectedIndex = 0; // Selecciona el primer item por defecto.

                // Cargar repartidores activos.
                var repartidores = logicaRepartidor.ObtenerActivos(); // Obtiene la lista de repartidores activos.
                cboRepartidor.Items.Clear(); // Limpia los items existentes en el ComboBox de repartidores.
                cboRepartidor.Items.Add("-- Seleccione Repartidor --"); // Agrega un item por defecto.

                foreach (var repartidor in repartidores) // Itera sobre cada repartidor.
                {
                    // Crea el texto a mostrar en el ComboBox.
                    string displayText = $"{repartidor.Nombre} {repartidor.PrimerApellido} {repartidor.SegundoApellido}";
                    // Agrega un nuevo ComboBoxItem con el repartidor y el texto.
                    cboRepartidor.Items.Add(new ComboBoxItem { Value = repartidor, Display = displayText });
                }
                cboRepartidor.SelectedIndex = 0; // Selecciona el primer item por defecto.

                // Cargar articulos activos.
                var articulos = logicaArticulo.ObtenerActivos(); // Obtiene la lista de articulos activos.
                cboArticulo.Items.Clear(); // Limpia los items existentes en el ComboBox de articulos.
                cboArticulo.Items.Add("-- Seleccione Articulo --"); // Agrega un item por defecto.

                foreach (var articulo in articulos) // Itera sobre cada articulo.
                {
                    // Crea el texto a mostrar en el ComboBox, incluyendo el inventario.
                    string displayText = $"{articulo.Nombre} (Disponible: {articulo.Inventario})";
                    // Agrega un nuevo ComboBoxItem con el articulo y el texto.
                    cboArticulo.Items.Add(new ComboBoxItem { Value = articulo, Display = displayText });
                }
                cboArticulo.SelectedIndex = 0; // Selecciona el primer item por defecto.
            }
            catch (Exception ex) // Captura cualquier excepcion que ocurra.
            {
                // Muestra un mensaje de error si la carga de datos falla.
                MessageBox.Show("Error al cargar los datos: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRegistrarPedido_Click(object sender, EventArgs e) // Evento Click del boton "Registrar Pedido".
        {
            try // Bloque try-catch para manejar posibles excepciones.
            {
                if (!pedidoGuardado) // Si el encabezado del pedido aun no ha sido guardado.
                {
                    GuardarEncabezadoPedido(); // Llama al metodo para guardar el encabezado.
                }
                else // Si el encabezado ya fue guardado.
                {
                    if (dgvDetalle.Rows.Count == 0) // Verifica si no se han agregado articulos al detalle.
                    {
                        // Muestra un mensaje de advertencia.
                        MessageBox.Show("Debe agregar al menos un articulo al pedido",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return; // Sale del metodo.
                    }

                    // Muestra un mensaje de exito si el pedido se ha registrado completamente.
                    MessageBox.Show("El pedido ha sido registrado exitosamente",
                        "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarFormulario(); // Llama al metodo para limpiar el formulario.
                }
            }
            catch (Exception ex) // Captura cualquier excepcion que ocurra.
            {
                // Muestra un mensaje de error.
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GuardarEncabezadoPedido() // Metodo para guardar el encabezado del pedido.
        {
            try // Bloque try-catch para manejar posibles excepciones.
            {
                // Validaciones.
                if (!int.TryParse(txtNumeroPedido.Text, out int numeroPedido)) // Intenta convertir el texto del numero de pedido a un entero.
                {
                    // Muestra un mensaje de error si la conversion falla.
                    MessageBox.Show("El numero de pedido debe ser un numero", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Sale del metodo.
                }

                if (dtpFechaPedido.Value.Date < DateTime.Today) // Valida que la fecha del pedido no sea anterior a hoy.
                {
                    // Muestra un mensaje de error.
                    MessageBox.Show("La fecha del pedido no puede ser anterior a hoy", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Sale del metodo.
                }

                if (cboCliente.SelectedIndex <= 0) // Valida que se haya seleccionado un cliente.
                {
                    // Muestra un mensaje de error.
                    MessageBox.Show("Debe seleccionar un cliente", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Sale del metodo.
                }

                if (cboRepartidor.SelectedIndex <= 0) // Valida que se haya seleccionado un repartidor.
                {
                    // Muestra un mensaje de error.
                    MessageBox.Show("Debe seleccionar un repartidor", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Sale del metodo.
                }

                if (string.IsNullOrWhiteSpace(txtDireccion.Text)) // Valida que la direccion no este vacia.
                {
                    // Muestra un mensaje de error.
                    MessageBox.Show("La direccion es requerida", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Sale del metodo.
                }

                PedidoEntidad pedido = new PedidoEntidad(); // Crea una nueva instancia de PedidoEntidad.
                pedido.NumeroPedido = numeroPedido; // Asigna el numero de pedido.
                pedido.FechaPedido = dtpFechaPedido.Value; // Asigna la fecha del pedido.

                // Obtiene el cliente seleccionado del ComboBox.
                ComboBoxItem selectedCliente = (ComboBoxItem)cboCliente.SelectedItem;
                pedido.Cliente = (ClienteEntidad)selectedCliente.Value; // Asigna el objeto ClienteEntidad al pedido.

                // Obtiene el repartidor seleccionado del ComboBox.
                ComboBoxItem selectedRepartidor = (ComboBoxItem)cboRepartidor.SelectedItem;
                pedido.Repartidor = (RepartidorEntidad)selectedRepartidor.Value; // Asigna el objeto RepartidorEntidad al pedido.

                pedido.Direccion = txtDireccion.Text; // Asigna la direccion del pedido.

                string resultado = logicaPedido.InsertarPedido(pedido); // Llama al metodo de logica de negocio para insertar el pedido.

                if (resultado == "Pedido registrado correctamente") // Si el registro fue exitoso.
                {
                    // Muestra un mensaje de exito.
                    MessageBox.Show("Encabezado del pedido guardado. Ahora agregue los articulos.",
                        "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    pedidoGuardado = true; // Cambia la bandera a true.
                    gbEncabezado.Enabled = false; // Deshabilita el GroupBox del encabezado.
                    btnRegistrarPedido.Text = "Finalizar Pedido"; // Cambia el texto del boton a "Finalizar Pedido".
                    cboArticulo.Focus(); // Pone el foco en el ComboBox de articulos.
                }
                else // Si hubo un problema al registrar el pedido.
                {
                    // Muestra un mensaje de advertencia.
                    MessageBox.Show(resultado, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex) // Captura cualquier excepcion que ocurra.
            {
                // Muestra un mensaje de error.
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAgregarArticulo_Click(object sender, EventArgs e) // Evento Click del boton "Agregar Articulo".
        {
            try // Bloque try-catch para manejar posibles excepciones.
            {
                if (!pedidoGuardado) // Valida si el encabezado del pedido ya fue guardado.
                {
                    // Muestra un mensaje de advertencia.
                    MessageBox.Show("Primero debe guardar el encabezado del pedido", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // Sale del metodo.
                }

                if (cboArticulo.SelectedIndex <= 0) // Valida que se haya seleccionado un articulo.
                {
                    // Muestra un mensaje de error.
                    MessageBox.Show("Debe seleccionar un articulo", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Sale del metodo.
                }

                if (!int.TryParse(txtCantidad.Text, out int cantidad)) // Intenta convertir el texto de la cantidad a un entero.
                {
                    // Muestra un mensaje de error si la conversion falla.
                    MessageBox.Show("La cantidad debe ser un numero", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Sale del metodo.
                }

                if (cantidad <= 0) // Valida que la cantidad sea mayor a cero.
                {
                    // Muestra un mensaje de error.
                    MessageBox.Show("La cantidad debe ser mayor a cero", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Sale del metodo.
                }

                // Obtiene el articulo seleccionado del ComboBox.
                ComboBoxItem selectedArticulo = (ComboBoxItem)cboArticulo.SelectedItem;
                ArticuloEntidad articuloSeleccionado = (ArticuloEntidad)selectedArticulo.Value; // Obtiene el objeto ArticuloEntidad.

                if (cantidad > articuloSeleccionado.Inventario) // Valida que la cantidad no exceda el inventario disponible.
                {
                    // Muestra un mensaje de error.
                    MessageBox.Show($"La cantidad no puede ser mayor al inventario disponible ({articuloSeleccionado.Inventario})",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Sale del metodo.
                }

                DetallePedidoEntidad detalle = new DetallePedidoEntidad(); // Crea una nueva instancia de DetallePedidoEntidad.
                detalle.NumeroPedido = int.Parse(txtNumeroPedido.Text); // Asigna el numero de pedido.
                detalle.Articulo = articuloSeleccionado; // Asigna el articulo seleccionado.
                detalle.Cantidad = cantidad; // Asigna la cantidad.

                // Calcular monto = (valor del articulo * cantidad) * 1.12 (aplicando el 12% de impuesto).
                double subtotal = articuloSeleccionado.Valor * cantidad;
                detalle.Monto = subtotal * 1.12;

                string resultado = logicaPedido.InsertarDetalle(detalle); // Llama al metodo de logica de negocio para insertar el detalle.

                if (resultado == "Articulo agregado al pedido") // Si el detalle fue agregado correctamente.
                {
                    // Muestra un mensaje de exito.
                    MessageBox.Show(resultado, "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    dgvDetalle.Rows.Add( // Agrega una nueva fila al DataGridView con los datos del detalle.
                        detalle.NumeroPedido,
                        detalle.Articulo.Id,
                        detalle.Articulo.Nombre,
                        // Muestra el nombre del tipo de articulo o "Sin tipo" si es nulo.
                        detalle.Articulo.TipoArticulo?.Nombre ?? "Sin tipo",
                        detalle.Cantidad,
                        detalle.Monto.ToString("C2") // Formatea el monto como moneda.
                    );

                    cboArticulo.SelectedIndex = 0; // Restablece la seleccion del ComboBox de articulos.
                    txtCantidad.Clear(); // Limpia el campo de texto de la cantidad.

                    // Recargar articulos para actualizar inventario (despues de restar la cantidad agregada).
                    CargarCombos();
                }
                else // Si hubo un problema al agregar el articulo al pedido.
                {
                    // Muestra un mensaje de advertencia.
                    MessageBox.Show(resultado, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex) // Captura cualquier excepcion que ocurra.
            {
                // Muestra un mensaje de error.
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarFormulario() // Metodo para limpiar todos los campos del formulario.
        {
            txtNumeroPedido.Clear(); // Limpia el campo de numero de pedido.
            dtpFechaPedido.Value = DateTime.Today; // Restablece la fecha a hoy.
            cboCliente.SelectedIndex = 0; // Restablece la seleccion del cliente.
            cboRepartidor.SelectedIndex = 0; // Restablece la seleccion del repartidor.
            txtDireccion.Clear(); // Limpia el campo de direccion.
            cboArticulo.SelectedIndex = 0; // Restablece la seleccion del articulo.
            txtCantidad.Clear(); // Limpia el campo de cantidad.
            dgvDetalle.Rows.Clear(); // Limpia todas las filas del DataGridView.

            pedidoGuardado = false; // Restablece la bandera de pedido guardado a false.
            gbEncabezado.Enabled = true; // Habilita el GroupBox del encabezado.
            gbDetalle.Enabled = true; // Habilita el GroupBox del detalle.
            btnRegistrarPedido.Text = "Guardar Pedido"; // Restablece el texto del boton.

            txtNumeroPedido.Focus(); // Pone el foco en el campo de numero de pedido.

            // Recargar combos para tener los datos actualizados.
            CargarCombos();
        }
        private void cboArticulo_SelectedIndexChanged(object sender, EventArgs e) // Evento SelectedIndexChanged del ComboBox de Articulos.
        {
            // Este metodo esta vacio, lo que significa que no hay una logica especifica
            // que se ejecute cuando cambia la seleccion del articulo en el ComboBox.
        }
    }
}
//Como referencias se utilizaron los libros (Como programar en C#, Harvey M. Deitel), (Guia de Estudio, Programacion Avanzada, Carlos H. Hernandez Alvarado, como tambien las tutorias del curso)


