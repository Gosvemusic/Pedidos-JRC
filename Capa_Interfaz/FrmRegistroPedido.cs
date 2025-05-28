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
            CargarCombos();
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

                // Cargar repartidores activos
                var repartidores = logicaRepartidor.ObtenerActivos();
                cboRepartidor.DataSource = repartidores;
                cboRepartidor.DisplayMember = "Nombre";
                cboRepartidor.ValueMember = "Identificacion";

                // Cargar artículos activos
                var articulos = logicaArticulo.ObtenerActivos();
                cboArticulo.DataSource = articulos;
                cboArticulo.DisplayMember = "Nombre";
                cboArticulo.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lblpedido_Click(object sender, EventArgs e)
        {
            try
            {
                PedidoEntidad pedido = new PedidoEntidad();

                // Validar número de pedido
                if (!int.TryParse(txtNumeroPedido.Text, out int numeroPedido))
                {
                    MessageBox.Show("El número de pedido debe ser un número", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    MessageBox.Show(resultado, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    pedidoGuardado = true;
                    gbEncabezado.Enabled = false;
                    gbDetalle.Enabled = true;
                }
                else
                {
                    MessageBox.Show(resultado, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRegistrarPedido_Click(object sender, EventArgs e)
        {

        }

        private void btnAgregarArticulo_Click(object sender, EventArgs e)
        {
            try
            {
                if (!pedidoGuardado)
                {
                    MessageBox.Show("Primero debe guardar el encabezado del pedido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DetallePedidoEntidad detalle = new DetallePedidoEntidad();

                // Validar cantidad
                if (!int.TryParse(txtCantidad.Text, out int cantidad))
                {
                    MessageBox.Show("La cantidad debe ser un número", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                detalle.NumeroPedido = int.Parse(txtNumeroPedido.Text);
                detalle.Articulo = (ArticuloEntidad)cboArticulo.SelectedItem;
                detalle.Cantidad = cantidad;

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
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
