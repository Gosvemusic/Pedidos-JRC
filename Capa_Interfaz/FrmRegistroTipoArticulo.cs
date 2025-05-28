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
    public partial class FrmRegistroTipoArticulo : Form
    {
        private LogTipoArticulo logica = new LogTipoArticulo();
        public FrmRegistroTipoArticulo()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                TipoArticuloEntidad tipo = new TipoArticuloEntidad();

                // Validar ID numérico
                if (!int.TryParse(txtId.Text, out int id))
                {
                    MessageBox.Show("El ID debe ser un número", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                tipo.Id = id;
                tipo.Nombre = txtNombre.Text;
                tipo.Descripcion = txtDescripcion.Text;

                string resultado = logica.Insertar(tipo);

                if (resultado == "El registro se ha ingresado correctamente")
                {
                    MessageBox.Show(resultado, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarCampos();
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

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }
        private void LimpiarCampos()
        {
            txtId.Clear();
            txtNombre.Clear();
            txtDescripcion.Clear();
            txtId.Focus();

        }
    }
}
