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
        private DataGridView dgvTiposArticulo;
        public FrmConsultaTipoArticulo()
        {
            InitializeComponent();
            CargarDatos();
        }

        private void dgvTipoArticulo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void CargarDatos()
        {
            try
            {
                
                var tipos = logica.ObtenerTodos();

                foreach (var tipo in tipos)
                {
                    dgvTiposArticulo.Rows.Add(
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
    }
}

