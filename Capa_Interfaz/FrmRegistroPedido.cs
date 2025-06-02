using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capa_Entidades;
using Capa_Log_Negocio;

namespace Capa_Interfaz
{
    public partial class FrmRegistroPedido : Form
    {
        private LogPedido logicaPedido = new LogPedido();
        private LogCliente logicaCliente = new LogCliente();
        private LogRepartidor logicaRepartidor = new LogRepartidor();
        private LogArticulo logicaArticulo = new LogArticulo();
        private List<DetallePedidoEntidad> detallesTemporales = new List<DetallePedidoEntidad>();
        private bool pedidoGuardado = false;

        public FrmRegistroPedido()
        {
            InitializeComponent();
            ConfigurarFormulario();
            CargarCombos();
            ConfigurarDataGridView();
        }

        private void ConfigurarFormulario()
        {
            // Configurar DateTimePicker para mostrar solo fecha
            dtpFechaPedido.Format = DateTimePickerFormat.Short;
            dtpFechaPedido.Value = DateTime.Today;

            // Habilitar todo al inicio
            gbEncabezado.Enabled = true;
            gbDetalle.Enabled = true;

            // Configurar el botón
            btnRegistrarPedido.Text = "Guardar Pedido";

            // Limpiar placeholders
            txtNumeroPedido.Text = "";
            txtDireccion.Text = "";
            txtCantidad.Text = "";
        }

        private void ConfigurarDataGridView()
        {
            dgvDetalle.Columns.Clear();
            dgvDetalle.Columns.Add("NumeroPedido", "Número Pedido");
            dgvDetalle.Columns.Add("IdArticulo", "ID Artículo");
            dgvDetalle.Columns.Add("NombreArticulo", "Nombre Artículo");
            dgvDetalle.Columns.Add("TipoArticulo", "Tipo Artículo");
            dgvDetalle.Columns.Add("Cantidad", "Cantidad");
            dgvDetalle.Columns.Add("Monto", "Monto");

            dgvDetalle.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDetalle.AllowUserToAddRows = false;
        }

        private class ComboBoxItem
        {
            public object Value { get; set; }
            public string Display { get; set; }

            public override string ToString()
            {
                return Display;
            }
        }

        private void CargarCombos()
        {
            try
            {
                // Cargar clientes activos
                var clientes = logicaCliente.ObtenerActivos();
                cboCliente.Items.Clear();
                cboCliente.Items.Add("-- Seleccione Cliente --");

                foreach (var cliente in clientes)
                {
                    string displayText = $"{cliente.Nombre} {cliente.PrimerApellido} {cliente.SegundoApellido}";
                    cboCliente.Items.Add(new ComboBoxItem { Value = cliente, Display = displayText });
                }
                cboCliente.SelectedIndex = 0;

                // Cargar repartidores activos
                var repartidores = logicaRepartidor.ObtenerActivos();
                cboRepartidor.Items.Clear();
                cboRepartidor.Items.Add("-- Seleccione Repartidor --");

                foreach (var repartidor in repartidores)
                {
                    string displayText = $"{repartidor.Nombre} {repartidor.PrimerApellido} {repartidor.SegundoApellido}";
                    cboRepartidor.Items.Add(new ComboBoxItem { Value = repartidor, Display = displayText });
                }
                cboRepartidor.SelectedIndex = 0;

                // Cargar artículos activos
                var articulos = logicaArticulo.ObtenerActivos();
                cboArticulo.Items.Clear();
                cboArticulo.Items.Add("-- Seleccione Artículo --");

                foreach (var articulo in articulos)
                {
                    string displayText = $"{articulo.Nombre} (Disponible: {articulo.Inventario})";
                    cboArticulo.Items.Add(new ComboBoxItem { Value = articulo, Display = displayText });
                }
                cboArticulo.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void btnRegistrarPedido_Click(object sender, EventArgs e)
        {
            try
            {
                if (!pedidoGuardado)
                {
                    GuardarEncabezadoPedido();
                }
                else
                {
                    if (dgvDetalle.Rows.Count == 0)
                    {
                        MessageBox.Show("Debe agregar al menos un artículo al pedido",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    MessageBox.Show("El pedido ha sido registrado exitosamente",
                        "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarFormulario();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void GuardarEncabezadoPedido()
        {
            try
            {
                // Validaciones
                if (!int.TryParse(txtNumeroPedido.Text, out int numeroPedido))
                {
                    MessageBox.Show("El número de pedido debe ser un número", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (dtpFechaPedido.Value.Date < DateTime.Today)
                {
                    MessageBox.Show("La fecha del pedido no puede ser anterior a hoy", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (cboCliente.SelectedIndex <= 0)
                {
                    MessageBox.Show("Debe seleccionar un cliente", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (cboRepartidor.SelectedIndex <= 0)
                {
                    MessageBox.Show("Debe seleccionar un repartidor", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtDireccion.Text))
                {
                    MessageBox.Show("La dirección es requerida", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                PedidoEntidad pedido = new PedidoEntidad();
                pedido.NumeroPedido = numeroPedido;
                pedido.FechaPedido = dtpFechaPedido.Value;

                ComboBoxItem selectedCliente = (ComboBoxItem)cboCliente.SelectedItem;
                pedido.Cliente = (ClienteEntidad)selectedCliente.Value;

                ComboBoxItem selectedRepartidor = (ComboBoxItem)cboRepartidor.SelectedItem;
                pedido.Repartidor = (RepartidorEntidad)selectedRepartidor.Value;

                pedido.Direccion = txtDireccion.Text;

                string resultado = logicaPedido.InsertarPedido(pedido);

                if (resultado == "Pedido registrado correctamente")
                {
                    MessageBox.Show("Encabezado del pedido guardado. Ahora agregue los artículos.",
                        "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    pedidoGuardado = true;
                    gbEncabezado.Enabled = false;
                    btnRegistrarPedido.Text = "Finalizar Pedido";
                    cboArticulo.Focus();
                }
                else
                {
                    MessageBox.Show(resultado, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnAgregarArticulo_Click(object sender, EventArgs e)
        {
            try
            {
                if (!pedidoGuardado)
                {
                    MessageBox.Show("Primero debe guardar el encabezado del pedido", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (cboArticulo.SelectedIndex <= 0)
                {
                    MessageBox.Show("Debe seleccionar un artículo", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!int.TryParse(txtCantidad.Text, out int cantidad))
                {
                    MessageBox.Show("La cantidad debe ser un número", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (cantidad <= 0)
                {
                    MessageBox.Show("La cantidad debe ser mayor a cero", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                ComboBoxItem selectedArticulo = (ComboBoxItem)cboArticulo.SelectedItem;
                ArticuloEntidad articuloSeleccionado = (ArticuloEntidad)selectedArticulo.Value;

                if (cantidad > articuloSeleccionado.Inventario)
                {
                    MessageBox.Show($"La cantidad no puede ser mayor al inventario disponible ({articuloSeleccionado.Inventario})",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DetallePedidoEntidad detalle = new DetallePedidoEntidad();
                detalle.NumeroPedido = int.Parse(txtNumeroPedido.Text);
                detalle.Articulo = articuloSeleccionado;
                detalle.Cantidad = cantidad;

                // Calcular monto = (valor del artículo * cantidad) * 1.12
                double subtotal = articuloSeleccionado.Valor * cantidad;
                detalle.Monto = subtotal * 1.12;

                string resultado = logicaPedido.InsertarDetalle(detalle);

                if (resultado == "Artículo agregado al pedido")
                {
                    MessageBox.Show(resultado, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    dgvDetalle.Rows.Add(
                        detalle.NumeroPedido,
                        detalle.Articulo.Id,
                        detalle.Articulo.Nombre,
                        detalle.Articulo.TipoArticulo?.Nombre ?? "Sin tipo",
                        detalle.Cantidad,
                        detalle.Monto.ToString("C2")
                    );

                    cboArticulo.SelectedIndex = 0;
                    txtCantidad.Clear();

                    // Recargar artículos para actualizar inventario
                    CargarCombos();
                }
                else
                {
                    MessageBox.Show(resultado, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarFormulario()
        {
            txtNumeroPedido.Clear();
            dtpFechaPedido.Value = DateTime.Today;
            cboCliente.SelectedIndex = 0;
            cboRepartidor.SelectedIndex = 0;
            txtDireccion.Clear();
            cboArticulo.SelectedIndex = 0;
            txtCantidad.Clear();
            dgvDetalle.Rows.Clear();

            pedidoGuardado = false;
            gbEncabezado.Enabled = true;
            gbDetalle.Enabled = true;
            btnRegistrarPedido.Text = "Guardar Pedido";

            txtNumeroPedido.Focus();

            // Recargar combos
            CargarCombos();
        }
private void cboArticulo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}


