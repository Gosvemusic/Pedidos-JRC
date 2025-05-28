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
    public partial class FrmRegistroCliente : Form
    {
        private LogCliente logica = new LogCliente();
        public FrmRegistroCliente()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                ClienteEntidad cliente = new ClienteEntidad();

                // Validar identificación numérica
                if (!int.TryParse(txtIdentificacion.Text, out int identificacion))
                {
                    MessageBox.Show("La identificación debe ser un número", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                cliente.Identificacion = identificacion;
                cliente.Nombre = txtNombre.Text;
                cliente.PrimerApellido = txtPrimerApellido.Text;
                cliente.SegundoApellido = txtSegundoApellido.Text;
                cliente.FechaNacimiento = dtpFechaNacimiento.Value;
                cliente.Activo = cboActivo.Text == "Sí";

                string resultado = logica.Insertar(cliente);

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
            txtIdentificacion.Clear();
            txtNombre.Clear();
            txtPrimerApellido.Clear();
            txtSegundoApellido.Clear();
            dtpFechaNacimiento.Value = DateTime.Now;
            cboActivo.SelectedIndex = -1;
            txtIdentificacion.Focus();
        }

    }
}
