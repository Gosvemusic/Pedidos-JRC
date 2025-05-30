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
    public partial class FrmConsultaTipoArticulo : Form
    {
        private LogTipoArticulo logica = new LogTipoArticulo();

        public FrmConsultaTipoArticulo()
        {
            InitializeComponent();
            ConfigurarDataGridView();
            CargarDatos();
        }

        private void ConfigurarDataGridView()
        {
            // Limpiar columnas existentes
            dgvTipoArticulo.Columns.Clear();

            // Agregar columnas
            dgvTipoArticulo.Columns.Add("ID", "ID");
            dgvTipoArticulo.Columns.Add("Nombre", "Nombre");
            dgvTipoArticulo.Columns.Add("Descripcion", "Descripción");

            // Configurar ancho de columnas
            dgvTipoArticulo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void CargarDatos()
        {
            try
            {
                dgvTipoArticulo.Rows.Clear();
                var tipos = logica.ObtenerTodos();

                foreach (var tipo in tipos)
                {
                    dgvTipoArticulo.Rows.Add(
                        tipo.Id,
                        tipo.Nombre,
                        tipo.Descripcion
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvTipoArticulo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}



