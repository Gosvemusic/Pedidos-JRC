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
        private DataGridView dgvEncabezados;
        private DataGridView dgvDetalles;
        public FrmConsultaPedido()
        {
            InitializeComponent();
            CargarDatos();
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
                MessageBox.Show("Error al cargar los datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("Error al cargar los detalles: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
