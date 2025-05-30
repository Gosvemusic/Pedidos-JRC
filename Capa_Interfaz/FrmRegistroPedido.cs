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

            // Deshabilitar la sección de detalle al inicio
            gbDetalle.Enabled = false;

            // Limpiar placeholders de los TextBox
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

        private void CargarCombos()
        {
            try
            {
                // Cargar clientes activos
                var clientes = logicaCliente.ObtenerActivos();
                cboCliente.DataSource = clientes;
                cboCliente.DisplayMember = "Nombre";
                cboCliente.ValueMember = "Identificacion";
                cboCliente.SelectedIndex = -1;

                // Cargar repartidores activos
                var repartidores = logicaRepartidor.ObtenerActivos();
                cboRepartidor.DataSource = repartidores;
                cboRepartidor.DisplayMember = "Nombre";
                cboRepartidor.ValueMember = "Identificacion";
                cboRepartidor.SelectedIndex = -1;

                // Cargar artículos activos
                var articulos = logicaArticulo.ObtenerActivos();
                cboArticulo.DataSource = articulos;
                cboArticulo.DisplayMember = "Nombre";
                cboArticulo.ValueMember = "Id";
                cboArticulo.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Este es el método correcto para guardar el pedido
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
                PedidoEntidad pedido = new PedidoEntidad();

                // Validar número de pedido
                if (!int.TryParse(txtNumeroPedido.Text, out int numeroPedido))
                {
                    MessageBox.Show("El número de pedido debe ser un número", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Validar fecha
                if (dtpFechaPedido.Value.Date < DateTime.Today)
                {
                    MessageBox.Show("La fecha del pedido no puede ser anterior a hoy", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Validar selecciones
                if (cboCliente.SelectedIndex == -1)
                {
                    MessageBox.Show("Debe seleccionar un cliente", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (cboRepartidor.SelectedIndex == -1)
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

                pedido.NumeroPedido = numeroPedido;
                pedido.FechaPedido = dtpFechaPedido.Value;
                pedido.Cliente = (ClienteEntidad)cboCliente.SelectedItem;
                pedido.Repartidor = (RepartidorEntidad)cboRepartidor.SelectedItem;
                pedido.Direccion = txtDireccion.Text;

                string resultado = logicaPedido.InsertarPedido(pedido);

                if (resultado == "Pedido registrado correctamente")
                {
                    MessageBox.Show("Encabezado del pedido guardado. Ahora puede agregar artículos.",
                        "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    pedidoGuardado = true;
                    gbEncabezado.Enabled = false;
                    gbDetalle.Enabled = true;
                    btnRegistrarPedido.Text = "Finalizar Pedido";
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

                if (cboArticulo.SelectedIndex == -1)
                {
                    MessageBox.Show("Debe seleccionar un artículo", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Validar cantidad
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

                ArticuloEntidad articuloSeleccionado = (ArticuloEntidad)cboArticulo.SelectedItem;

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
                detalle.Monto = articuloSeleccionado.Valor * cantidad * 1.12; // +12% de envío

                string resultado = logicaPedido.InsertarDetalle(detalle);

                if (resultado == "Artículo agregado al pedido")
                {
                    MessageBox.Show(resultado, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Agregar al DataGridView
                    dgvDetalle.Rows.Add(
                        detalle.NumeroPedido,
                        detalle.Articulo.Id,
                        detalle.Articulo.Nombre,
                        detalle.Articulo.TipoArticulo.Nombre,
                        detalle.Cantidad,
                        detalle.Monto.ToString("C")
                    );

                    // Limpiar campos
                    cboArticulo.SelectedIndex = -1;
                    txtCantidad.Clear();

                    // Recargar artículos activos
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
            cboCliente.SelectedIndex = -1;
            cboRepartidor.SelectedIndex = -1;
            txtDireccion.Clear();
            cboArticulo.SelectedIndex = -1;
            txtCantidad.Clear();
            dgvDetalle.Rows.Clear();

            pedidoGuardado = false;
            gbEncabezado.Enabled = true;
            gbDetalle.Enabled = false;
            btnRegistrarPedido.Text = "Registrar Pedido";

            txtNumeroPedido.Focus();
        }
    }
}


