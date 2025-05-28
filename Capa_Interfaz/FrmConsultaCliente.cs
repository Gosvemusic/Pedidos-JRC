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
    public partial class FrmConsultaCliente : Form
    {
        private LogCliente logica = new LogCliente();
        private DataGridView dgvClientes;
        public FrmConsultaCliente()
        {
            InitializeComponent();
            CargarDatos();
        }
        private void CargarDatos()
        {
            try
            {
                dgvClientes.Rows.Clear();
                var clientes = logica.ObtenerTodos();

                foreach (var cliente in clientes)
                {
                    dgvClientes.Rows.Add(
                        cliente.Identificacion,
                        cliente.Nombre,
                        cliente.PrimerApellido,
                        cliente.SegundoApellido,
                        cliente.FechaNacimiento.ToString("dd/MM/yyyy"),
                        cliente.Activo ? "Sí" : "No"
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
