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

        public FrmConsultaRepartidor()
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
            dataGridView1.Columns.Add("Identificacion", "Identificación");
            dataGridView1.Columns.Add("Nombre", "Nombre");
            dataGridView1.Columns.Add("PrimerApellido", "Primer Apellido");
            dataGridView1.Columns.Add("SegundoApellido", "Segundo Apellido");
            dataGridView1.Columns.Add("FechaNacimiento", "Fecha de Nacimiento");
            dataGridView1.Columns.Add("FechaContratacion", "Fecha de Contratación");
            dataGridView1.Columns.Add("Activo", "Activo");

            // Configurar ancho de columnas
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void CargarDatos()
        {
            try
            {
                dataGridView1.Rows.Clear();
                var repartidores = logica.ObtenerTodos();

                foreach (var repartidor in repartidores)
                {
                    dataGridView1.Rows.Add(
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

