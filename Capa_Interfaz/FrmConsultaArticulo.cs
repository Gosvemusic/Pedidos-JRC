//* [UNED Perez Zeledon]
//* II Cuatrimestre 2025
//* Sistema de Gestion de Pedidos
//* [Javier Rojas Cordero]
//* Fecha: 27/05/2025

using System; // Importa el espacio de nombres System para funcionalidades basicas como el manejo de excepciones.
using System.Collections.Generic; // Importa el espacio de nombres para colecciones genericas.
using System.ComponentModel; // Importa el espacio de nombres para componentes y su comportamiento.
using System.Data; // Importa el espacio de nombres para acceso a datos.
using System.Drawing; // Importa el espacio de nombres para graficos GDI+.
using System.Linq; // Importa el espacio de nombres para LINQ (Language Integrated Query).
using System.Text; // Importa el espacio de nombres para codificacion de caracteres.
using System.Threading.Tasks; // Importa el espacio de nombres para programacion asincrona.
using System.Windows.Forms; // Importa el espacio de nombres para construir aplicaciones con interfaz grafica de usuario de Windows Forms.
using Capa_Log_Negocio; // Importa el espacio de nombres Capa_Log_Negocio para acceder a la logica de negocio.

namespace Capa_Interfaz // Define el espacio de nombres para la capa de interfaz de usuario.
{
    public partial class FrmConsultaArticulo : Form // Declara la clase FrmConsultaArticulo, que es un formulario de Windows Forms.
    {
        private LogArticulo logica = new LogArticulo(); // Crea una instancia privada de LogArticulo para interactuar con la logica de negocio de articulos.

        public FrmConsultaArticulo() // Constructor de la clase FrmConsultaArticulo.
        {
            InitializeComponent(); // Llama al metodo generado automaticamente para inicializar los componentes del formulario.
            ConfigurarDataGridView(); // Llama a un metodo para configurar el control DataGridView.
            CargarDatos(); // Llama a un metodo para cargar los datos en el DataGridView al iniciar el formulario.
        }

        private void ConfigurarDataGridView() // Metodo privado para configurar las columnas del DataGridView.
        {
            // Limpiar columnas existentes // Comentario que indica la accion de limpiar columnas.
            dataGridView1.Columns.Clear(); // Elimina todas las columnas existentes en el DataGridView.

            // Agregar columnas // Comentario que indica la accion de agregar nuevas columnas.
            dataGridView1.Columns.Add("ID", "ID"); // Agrega una columna con el nombre interno "ID" y el encabezado visible "ID".
            dataGridView1.Columns.Add("Nombre", "Nombre"); // Agrega una columna para el nombre del articulo.
            dataGridView1.Columns.Add("TipoArticulo", "Tipo de Articulo"); // Agrega una columna para el tipo de articulo.
            dataGridView1.Columns.Add("Valor", "Valor"); // Agrega una columna para el valor del articulo.
            dataGridView1.Columns.Add("Inventario", "Inventario"); // Agrega una columna para la cantidad en inventario.
            dataGridView1.Columns.Add("Activo", "Activo"); // Agrega una columna para el estado activo del articulo.

            // Configurar ancho de columnas // Comentario que indica la configuracion del ancho de las columnas.
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Configura el modo de ajuste automatico de columnas para que llenen todo el ancho del control.
        }

        private void CargarDatos() // Metodo privado para cargar los datos de los articulos en el DataGridView.
        {
            try // Inicia un bloque try para manejar posibles excepciones durante la carga de datos.
            {
                dataGridView1.Rows.Clear(); // Limpia todas las filas existentes en el DataGridView.
                var articulos = logica.ObtenerTodos(); // Obtiene todos los articulos utilizando el metodo de la capa de logica de negocio.

                foreach (var articulo in articulos) // Itera sobre cada articulo obtenido.
                {
                    dataGridView1.Rows.Add( // Agrega una nueva fila al DataGridView con los datos del articulo actual.
                        articulo.Id, // Celda para el ID del articulo.
                        articulo.Nombre, // Celda para el nombre del articulo.
                        articulo.TipoArticulo?.Nombre ?? "Sin tipo", // Celda para el nombre del tipo de articulo (si existe, de lo contrario "Sin tipo").
                        articulo.Valor.ToString("C"), // Celda para el valor del articulo, formateado como moneda.
                        articulo.Inventario, // Celda para la cantidad en inventario.
                        articulo.Activo ? "Si" : "No" // Celda para el estado activo del articulo, mostrando "Si" o "No".
                    );
                }
            }
            catch (Exception ex) // Captura cualquier excepcion generica que pueda ocurrir durante la carga de datos.
            {
                MessageBox.Show("Error al cargar los datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // Muestra un mensaje de error al usuario.
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) // Manejador de eventos para el clic en el contenido de una celda del DataGridView.
        {
            // Este metodo esta vacio, lo que significa que no hay logica especifica implementada para el clic en el contenido de la celda en este momento.
        }
    }
}
//Como referencias se utilizaron los libros (Como programar en C#, Harvey M. Deitel), (Guia de Estudio, Programacion Avanzada, Carlos H. Hernandez Alvarado, como tambien las tutorias del curso)
