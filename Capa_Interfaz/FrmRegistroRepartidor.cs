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
    public partial class FrmRegistroRepartidor : Form
    {
        private LogRepartidor logica = new LogRepartidor();
        public FrmRegistroRepartidor()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                RepartidorEntidad repartidor = new RepartidorEntidad();

                // Validar identificación numérica
                if (!int.TryParse(txtIdentificacion.Text, out int identificacion))
                {
                    MessageBox.Show("La identificación debe ser un número", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                repartidor.Identificacion = identificacion;
                repartidor.Nombre = txtNombre.Text;
                repartidor.PrimerApellido = txtPrimerApellido.Text;
                repartidor.SegundoApellido = txtSegundoApellido.Text;
                repartidor.FechaNacimiento = dtpFechaNacimiento.Value;
                repartidor.FechaContratacion = dtpFechaContratacion.Value;
                repartidor.Activo = cboActivo.Text == "Sí";

                string resultado = logica.Insertar(repartidor);

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
            dtpFechaContratacion.Value = DateTime.Now;
            cboActivo.SelectedIndex = -1;
            txtIdentificacion.Focus();
        }

        private void cboActivo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

