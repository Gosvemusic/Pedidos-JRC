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
    public partial class FrmConsultaRepartidor : Form
    {
        private LogRepartidor logica = new LogRepartidor();
        private DataGridView dgvRepartidores;
        public FrmConsultaRepartidor()
        {
            InitializeComponent();
            CargarDatos();
        }

        private void CargarDatos()
        {
            try
            {
                dgvRepartidores.Rows.Clear();
                var repartidores = logica.ObtenerTodos();

                foreach (var repartidor in repartidores)
                {
                    dgvRepartidores.Rows.Add(
                        repartidor.Identificacion,
                        repartidor.Nombre,
                        repartidor.PrimerApellido,
                        repartidor.SegundoApellido,
                        repartidor.FechaNacimiento.ToString("dd/MM/yyyy"),
                        repartidor.FechaContratacion.ToString("dd/MM/yyyy"),
                        repartidor.Activo ? "Sí" : "No"
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
