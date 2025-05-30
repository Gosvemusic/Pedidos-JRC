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
    public partial class FrmRegistroArticulo : Form
    {
        private LogArticulo logicaArticulo = new LogArticulo();
        private LogTipoArticulo logicaTipo = new LogTipoArticulo();
        public FrmRegistroArticulo()
        {
            InitializeComponent();
            CargarTiposArticulo();
            ConfigurarComboActivo();

        }
      

        private void CargarTiposArticulo()
        {
            try
            {
                var tipos = logicaTipo.ObtenerTodos();
                cboTipoArticulo.DisplayMember = "Nombre";
                cboTipoArticulo.ValueMember = "Id";
                cboTipoArticulo.DataSource = tipos;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar tipos de artículo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarComboActivo()
        {
            cboActivo.Items.Clear();
            cboActivo.Items.Add("Sí");
            cboActivo.Items.Add("No");
            cboActivo.SelectedIndex = 0; // Por defecto "Sí"
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                ArticuloEntidad articulo = new ArticuloEntidad();

                // Validar ID numerico
                if (!int.TryParse(txtId.Text, out int id))
                {
                    MessageBox.Show("El ID debe ser un número", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Validar valor numerico
                if (!double.TryParse(txtValor.Text, out double valor))
                {
                    MessageBox.Show("El valor debe ser un número", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Validar inventario numerico
                if (!int.TryParse(txtInventario.Text, out int inventario))
                {
                    MessageBox.Show("El inventario debe ser un número", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                articulo.Id = id;
                articulo.Nombre = txtNombre.Text;
                articulo.TipoArticulo = (TipoArticuloEntidad)cboTipoArticulo.SelectedItem;
                articulo.Valor = valor;
                articulo.Inventario = inventario;
                articulo.Activo = cboActivo.Text == "Sí";

                string resultado = logicaArticulo.Insertar(articulo);

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
            cboTipoArticulo.SelectedIndex = -1;
            txtValor.Clear();
            txtInventario.Clear();
            cboActivo.SelectedIndex = -1;
            txtId.Focus();
        }


    }
}

