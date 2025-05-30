using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capa_Log_Negocio;

namespace Capa_Interfaz
{
    public partial class FrmConsultaPedido : Form
    {
        private LogPedido logica = new LogPedido();
        private Label lblEncabezados;
        private Label lblDetalles;

        public FrmConsultaPedido()
        {
            InitializeComponent();
            ConfigurarFormulario();
            ConfigurarDataGridViews();
            CargarDatos();
        }

        private void ConfigurarFormulario()
        {
            // Configurar el formulario
            this.Text = "Consulta de Pedidos";
            this.Size = new Size(1000, 700);

            // Crear y configurar controles
            lblEncabezados = new Label();
            lblEncabezados.Text = "Encabezados de Pedidos";
            lblEncabezados.Location = new Point(12, 12);
            lblEncabezados.Size = new Size(200, 20);

            dgvEncabezados = new DataGridView();
            dgvEncabezados.Location = new Point(12, 35);
            dgvEncabezados.Size = new Size(960, 250);
            dgvEncabezados.AllowUserToAddRows = false;
            dgvEncabezados.ReadOnly = true;
            dgvEncabezados.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEncabezados.SelectionChanged += dgvEncabezados_SelectionChanged;

            lblDetalles = new Label();
            lblDetalles.Text = "Detalles del Pedido";
            lblDetalles.Location = new Point(12, 300);
            lblDetalles.Size = new Size(200, 20);

            dgvDetalles = new DataGridView();
            dgvDetalles.Location = new Point(12, 323);
            dgvDetalles.Size = new Size(960, 250);
            dgvDetalles.AllowUserToAddRows = false;
            dgvDetalles.ReadOnly = true;

            // Agregar controles al formulario
            this.Controls.Add(lblEncabezados);
            this.Controls.Add(dgvEncabezados);
            this.Controls.Add(lblDetalles);
            this.Controls.Add(dgvDetalles);

        }

        private void ConfigurarDataGridViews()
        {
            // Configurar columnas del grid de encabezados (11 columnas)
            dgvEncabezados.Columns.Clear();
            dgvEncabezados.Columns.Add("NumeroPedido", "Número de Pedido");
            dgvEncabezados.Columns.Add("FechaPedido", "Fecha de Pedido");
            dgvEncabezados.Columns.Add("ClienteId", "Cliente ID");
            dgvEncabezados.Columns.Add("ClienteNombre", "Nombre Cliente");
            dgvEncabezados.Columns.Add("ClientePrimerApellido", "Primer Apellido");
            dgvEncabezados.Columns.Add("ClienteSegundoApellido", "Segundo Apellido");
            dgvEncabezados.Columns.Add("RepartidorId", "Repartidor ID");
            dgvEncabezados.Columns.Add("RepartidorNombre", "Nombre Repartidor");
            dgvEncabezados.Columns.Add("RepartidorPrimerApellido", "Primer Apellido");
            dgvEncabezados.Columns.Add("RepartidorSegundoApellido", "Segundo Apellido");
            dgvEncabezados.Columns.Add("Direccion", "Dirección");

            dgvEncabezados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            // Configurar columnas del grid de detalles (5 columnas)
            dgvDetalles.Columns.Clear();
            dgvDetalles.Columns.Add("ArticuloId", "ID Artículo");
            dgvDetalles.Columns.Add("ArticuloNombre", "Nombre Artículo");
            dgvDetalles.Columns.Add("TipoArticulo", "Tipo de Artículo");
            dgvDetalles.Columns.Add("Cantidad", "Cantidad");
            dgvDetalles.Columns.Add("Monto", "Monto");

            dgvDetalles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void CargarDatos()
        {
            try
            {
                dgvEncabezados.Rows.Clear();
                var pedidos = logica.ObtenerTodos();

                foreach (var pedido in pedidos)
                {
                    dgvEncabezados.Rows.Add(
                        pedido.NumeroPedido,
                        pedido.FechaPedido.ToString("dd/MM/yyyy"),
                        pedido.Cliente.Identificacion,
                        pedido.Cliente.Nombre,
                        pedido.Cliente.PrimerApellido,
                        pedido.Cliente.SegundoApellido,
                        pedido.Repartidor.Identificacion,
                        pedido.Repartidor.Nombre,
                        pedido.Repartidor.PrimerApellido,
                        pedido.Repartidor.SegundoApellido,
                        pedido.Direccion
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvEncabezados_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                dgvDetalles.Rows.Clear();

                if (dgvEncabezados.CurrentRow != null)
                {
                    int numeroPedido = Convert.ToInt32(dgvEncabezados.CurrentRow.Cells["NumeroPedido"].Value);
                    var detalles = logica.ObtenerDetallesPorPedido(numeroPedido);

                    foreach (var detalle in detalles)
                    {
                        dgvDetalles.Rows.Add(
                            detalle.Articulo.Id,
                            detalle.Articulo.Nombre,
                            detalle.Articulo.TipoArticulo.Nombre,
                            detalle.Cantidad,
                            detalle.Monto.ToString("C")
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los detalles: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Método vacío del designer
        }
    }
}

