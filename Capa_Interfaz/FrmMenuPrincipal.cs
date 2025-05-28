using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Capa_Interfaz
{
    public partial class FrmMenuPrincipal : Form
    {
        public FrmMenuPrincipal()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            FrmRegistroTipoArticulo frm = new FrmRegistroTipoArticulo();
            frm.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmConsultaTipoArticulo frm = new FrmConsultaTipoArticulo();
            frm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmRegistroArticulo frm = new FrmRegistroArticulo();
            frm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FrmConsultaArticulo frm = new FrmConsultaArticulo();
            frm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FrmRegistroCliente frm = new FrmRegistroCliente();
            frm.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FrmConsultaCliente frm = new FrmConsultaCliente();
            frm.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            FrmRegistroRepartidor frm = new FrmRegistroRepartidor();
            frm.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            FrmConsultaRepartidor frm = new FrmConsultaRepartidor();
            frm.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            FrmRegistroPedido frm = new FrmRegistroPedido();
            frm.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            FrmConsultaPedido frm = new FrmConsultaPedido();
            frm.Show();
        }
    }
}
