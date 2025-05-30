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
    public partial class FrmConsultaArticulo : Form
    {
        private LogArticulo logica = new LogArticulo();

        public FrmConsultaArticulo()
        {
            InitializeComponent();
            ConfigurarDataGridView();
            CargarDatos();
        }

        private void ConfigurarDataGridView()
        {
            // Limpiar columnas existentes
            dataGridView1.Columns.Clear();

            // Agregar columnas
            dataGridView1.Columns.Add("ID", "ID");
            dataGridView1.Columns.Add("Nombre", "Nombre");
            dataGridView1.Columns.Add("TipoArticulo", "Tipo de Artículo");
            dataGridView1.Columns.Add("Valor", "Valor");
            dataGridView1.Columns.Add("Inventario", "Inventario");
            dataGridView1.Columns.Add("Activo", "Activo");

            // Configurar ancho de columnas
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void CargarDatos()
        {
            try
            {
                dataGridView1.Rows.Clear();
                var articulos = logica.ObtenerTodos();

                foreach (var articulo in articulos)
                {
                    dataGridView1.Rows.Add(
                        articulo.Id,
                        articulo.Nombre,
                        articulo.TipoArticulo?.Nombre ?? "Sin tipo",
                        articulo.Valor.ToString("C"),
                        articulo.Inventario,
                        articulo.Activo ? "Sí" : "No"
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
