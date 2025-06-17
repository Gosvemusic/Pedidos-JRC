//* [UNED Perez Zeledon]
//* II Cuatrimestre 2025
//* Sistema de Gestion de Pedidos
//* [Javier Rojas Cordero]
//* Fecha: 27/05/2025

using System; // Importa el espacio de nombres System para funcionalidades basicas como el manejo de excepciones.
using System.Collections.Generic; // Importa el espacio de nombres para colecciones genericas (ej. List).
using System.ComponentModel; // Importa el espacio de nombres para atributos de componentes.
using System.Data; // Importa el espacio de nombres para el manejo de datos (ej. DataTable).
using System.Drawing; // Importa el espacio de nombres para objetos graficos (ej. Font, Point, Size).
using System.Linq; // Importa el espacio de nombres para LINQ (Language Integrated Query) para consultas mas sencillas.
using System.Text; // Importa el espacio de nombres para el manejo de cadenas de texto.
using System.Threading.Tasks; // Importa el espacio de nombres para programacion asincrona.
using System.Windows.Forms; // Importa el espacio de nombres para construir aplicaciones con interfaz grafica de usuario de Windows Forms.
using Capa_Log_Negocio; // Importa el espacio de nombres Capa_Log_Negocio para acceder a la logica de negocio.

namespace Capa_Interfaz // Define el espacio de nombres para la capa de interfaz de usuario de la aplicacion.
{
    public partial class FrmConsultaTipoArticulo : Form // Declara la clase publica FrmConsultaTipoArticulo, que representa un formulario para consultar tipos de articulo. Es una clase parcial, lo que significa que parte de su definicion esta en otro archivo (generalmente generado por el diseñador).
    {
        private LogTipoArticulo logica = new LogTipoArticulo(); // Crea una instancia privada de LogTipoArticulo para interactuar con la logica de negocio de tipos de articulo.

        public FrmConsultaTipoArticulo() // Constructor de la clase FrmConsultaTipoArticulo.
        {
            InitializeComponent(); // Llama al metodo generado automaticamente por el diseñador para inicializar los componentes visuales del formulario.
            ConfigurarDataGridView(); // Llama a un metodo personalizado para configurar las columnas del DataGridView.
            CargarDatos(); // Llama a un metodo para cargar los datos de los tipos de articulo en el DataGridView al iniciar el formulario.
        }

        private void ConfigurarDataGridView() // Metodo privado para configurar las columnas del DataGridView.
        {
            // Limpiar columnas existentes // Comentario que indica la accion de limpiar columnas.
            dgvTipoArticulo.Columns.Clear(); // Elimina todas las columnas existentes en el DataGridView, si las hubiera.

            // Agregar columnas // Comentario que indica la accion de agregar nuevas columnas.
            dgvTipoArticulo.Columns.Add("ID", "ID"); // Agrega una columna con el nombre interno "ID" y el encabezado visible "ID".
            dgvTipoArticulo.Columns.Add("Nombre", "Nombre"); // Agrega una columna para el nombre del tipo de articulo.
            dgvTipoArticulo.Columns.Add("Descripcion", "Descripcion"); // Agrega una columna para la descripcion del tipo de articulo.

            // Configurar ancho de columnas // Comentario que indica la configuracion del ancho de las columnas.
            dgvTipoArticulo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Configura el modo de ajuste automatico de columnas para que llenen todo el ancho disponible del control.
        }

        private void CargarDatos() // Metodo privado para cargar los datos de los tipos de articulo en el DataGridView.
        {
            try // Inicia un bloque try para manejar posibles excepciones durante la carga de datos.
            {
                dgvTipoArticulo.Rows.Clear(); // Limpia todas las filas existentes en el DataGridView antes de cargar nuevos datos.
                var tipos = logica.ObtenerTodos(); // Obtiene todos los tipos de articulo utilizando el metodo de la capa de logica de negocio.

                foreach (var tipo in tipos) // Itera sobre cada objeto de tipo de articulo obtenido.
                {
                    dgvTipoArticulo.Rows.Add( // Agrega una nueva fila al DataGridView con los datos del tipo de articulo actual.
                        tipo.Id, // Celda para el ID del tipo de articulo.
                        tipo.Nombre, // Celda para el nombre del tipo de articulo.
                        tipo.Descripcion // Celda para la descripcion del tipo de articulo.
                    );
                }
            }
            catch (Exception ex) // Captura cualquier excepcion generica que pueda ocurrir durante la carga de datos.
            {
                MessageBox.Show("Error al cargar los datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // Muestra un mensaje de error al usuario.
            }
        }

        private void dgvTipoArticulo_CellContentClick(object sender, DataGridViewCellEventArgs e) // Manejador de eventos para el clic en el contenido de una celda del DataGridView.
        {
            
        }
    }
}
//Como referencias se utilizaron los libros (Como programar en C#, Harvey M. Deitel), (Guia de Estudio, Programacion Avanzada, Carlos H. Hernandez Alvarado, como tambien las tutorias del curso)



