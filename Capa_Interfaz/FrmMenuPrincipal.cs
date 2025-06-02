//* [UNED Perez Zeledon]
//* II Cuatrimestre 2025
//* Sistema de Gestion de Pedidos
//* [Javier Rojas Cordero]
//* Fecha: 27/05/2025

using System; // Importa el espacio de nombres System, que contiene tipos fundamentales y funcionalidades basicas.
using System.Collections.Generic; // Importa el espacio de nombres para colecciones genericas (ej. List, Dictionary).
using System.ComponentModel; // Importa el espacio de nombres para atributos de componentes.
using System.Data; // Importa el espacio de nombres para el manejo de datos (ej. DataTable, DataSet).
using System.Drawing; // Importa el espacio de nombres para objetos graficos (ej. Font, Color).
using System.Linq; // Importa el espacio de nombres para LINQ (Language Integrated Query) que permite consultas mas sencillas.
using System.Text; // Importa el espacio de nombres para la manipulacion de cadenas de texto y codificaciones.
using System.Threading.Tasks; // Importa el espacio de nombres para trabajar con tareas asincronas.
using System.Windows.Forms; // Importa el espacio de nombres para construir aplicaciones con interfaz grafica de usuario de Windows Forms.

namespace Capa_Interfaz // Define el espacio de nombres para la capa de interfaz de usuario de la aplicacion.
{
    public partial class FrmMenuPrincipal : Form // Declara la clase publica FrmMenuPrincipal, que representa el formulario principal de la aplicacion. Es una clase parcial, lo que permite que su definicion este dividida en varios archivos (uno para la logica y otro para el diseño).
    {
        public FrmMenuPrincipal() // Constructor de la clase FrmMenuPrincipal.
        {
            InitializeComponent(); // Llama al metodo generado automaticamente por el diseñador para inicializar y configurar todos los componentes visuales del formulario.
        }

        private void button1_Click(object sender, EventArgs e) // Manejador de eventos para el clic del 'button1'.
        {
            FrmRegistroTipoArticulo frm = new FrmRegistroTipoArticulo(); // Crea una nueva instancia del formulario FrmRegistroTipoArticulo.
            frm.Show(); // Muestra el formulario FrmRegistroTipoArticulo.
        }

        private void button2_Click(object sender, EventArgs e) // Manejador de eventos para el clic del 'button2'.
        {
            FrmConsultaTipoArticulo frm = new FrmConsultaTipoArticulo(); // Crea una nueva instancia del formulario FrmConsultaTipoArticulo.
            frm.Show(); // Muestra el formulario FrmConsultaTipoArticulo.
        }

        private void button3_Click(object sender, EventArgs e) // Manejador de eventos para el clic del 'button3'.
        {
            FrmRegistroArticulo frm = new FrmRegistroArticulo(); // Crea una nueva instancia del formulario FrmRegistroArticulo.
            frm.Show(); // Muestra el formulario FrmRegistroArticulo.
        }

        private void button4_Click(object sender, EventArgs e) // Manejador de eventos para el clic del 'button4'.
        {
            FrmConsultaArticulo frm = new FrmConsultaArticulo(); // Crea una nueva instancia del formulario FrmConsultaArticulo.
            frm.Show(); // Muestra el formulario FrmConsultaArticulo.
        }

        private void button5_Click(object sender, EventArgs e) // Manejador de eventos para el clic del 'button5'.
        {
            FrmRegistroCliente frm = new FrmRegistroCliente(); // Crea una nueva instancia del formulario FrmRegistroCliente.
            frm.Show(); // Muestra el formulario FrmRegistroCliente.
        }

        private void button6_Click(object sender, EventArgs e) // Manejador de eventos para el clic del 'button6'.
        {
            FrmConsultaCliente frm = new FrmConsultaCliente(); // Crea una nueva instancia del formulario FrmConsultaCliente.
            frm.Show(); // Muestra el formulario FrmConsultaCliente.
        }

        private void button7_Click(object sender, EventArgs e) // Manejador de eventos para el clic del 'button7'.
        {
            FrmRegistroRepartidor frm = new FrmRegistroRepartidor(); // Crea una nueva instancia del formulario FrmRegistroRepartidor.
            frm.Show(); // Muestra el formulario FrmRegistroRepartidor.
        }

        private void button8_Click(object sender, EventArgs e) // Manejador de eventos para el clic del 'button8'.
        {
            FrmConsultaRepartidor frm = new FrmConsultaRepartidor(); // Crea una nueva instancia del formulario FrmConsultaRepartidor.
            frm.Show(); // Muestra el formulario FrmConsultaRepartidor.
        }

        private void button9_Click(object sender, EventArgs e) // Manejador de eventos para el clic del 'button9'.
        {
            FrmRegistroPedido frm = new FrmRegistroPedido(); // Crea una nueva instancia del formulario FrmRegistroPedido.
            frm.Show(); // Muestra el formulario FrmRegistroPedido.
        }

        private void button10_Click(object sender, EventArgs e) // Manejador de eventos para el clic del 'button10'.
        {
            FrmConsultaPedido frm = new FrmConsultaPedido(); // Crea una nueva instancia del formulario FrmConsultaPedido.
            frm.Show(); // Muestra el formulario FrmConsultaPedido.
        }
    }
}
//Como referencias se utilizaron los libros (Como programar en C#, Harvey M. Deitel), (Guia de Estudio, Programacion Avanzada, Carlos H. Hernandez Alvarado, como tambien las tutorias del curso)
