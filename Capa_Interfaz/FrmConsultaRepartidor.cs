//* [UNED Perez Zeledon]
//* II Cuatrimestre 2025
//* Sistema de Gestion de Pedidos
//* [Javier Rojas Cordero]
//* Fecha: 27/05/2025

using System; // Importa el espacio de nombres System para funcionalidades basicas como el manejo de excepciones y tipos de fecha.
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
    public partial class FrmConsultaRepartidor : Form // Declara la clase publica FrmConsultaRepartidor, que representa un formulario de consulta de repartidores. Es una clase parcial, lo que significa que parte de su definicion esta en otro archivo (normalmente generado por el diseñador).
    {
        private LogRepartidor logica = new LogRepartidor(); // Crea una instancia privada de LogRepartidor para interactuar con la logica de negocio de repartidores.

        public FrmConsultaRepartidor() // Constructor de la clase FrmConsultaRepartidor.
        {
            InitializeComponent(); // Llama al metodo generado automaticamente por el diseñador para inicializar los componentes visuales del formulario.
            ConfigurarDataGridView(); // Llama a un metodo personalizado para configurar las columnas del DataGridView.
            CargarDatos(); // Llama a un metodo para cargar los datos de los repartidores en el DataGridView al iniciar el formulario.
        }

        private void ConfigurarDataGridView() // Metodo privado para configurar las columnas del DataGridView.
        {
            // Limpiar columnas existentes // Comentario que indica la accion de limpiar columnas.
            dataGridView1.Columns.Clear(); // Elimina todas las columnas existentes en el DataGridView, si las hubiera.

            // Agregar columnas // Comentario que indica la accion de agregar nuevas columnas.
            dataGridView1.Columns.Add("Identificacion", "Identificacion"); // Agrega una columna con el nombre interno "Identificacion" y el encabezado visible "Identificacion".
            dataGridView1.Columns.Add("Nombre", "Nombre"); // Agrega una columna para el nombre del repartidor.
            dataGridView1.Columns.Add("PrimerApellido", "Primer Apellido"); // Agrega una columna para el primer apellido del repartidor.
            dataGridView1.Columns.Add("SegundoApellido", "Segundo Apellido"); // Agrega una columna para el segundo apellido del repartidor.
            dataGridView1.Columns.Add("FechaNacimiento", "Fecha de Nacimiento"); // Agrega una columna para la fecha de nacimiento del repartidor.
            dataGridView1.Columns.Add("FechaContratacion", "Fecha de Contratacion"); // Agrega una columna para la fecha de contratacion del repartidor.
            dataGridView1.Columns.Add("Activo", "Activo"); // Agrega una columna para el estado activo/inactivo del repartidor.

            // Configurar ancho de columnas // Comentario que indica la configuracion del ancho de las columnas.
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Configura el modo de ajuste automatico de columnas para que llenen todo el ancho disponible del control.
        }

        private void CargarDatos() // Metodo privado para cargar los datos de los repartidores en el DataGridView.
        {
            try // Inicia un bloque try para manejar posibles excepciones durante la carga de datos.
            {
                dataGridView1.Rows.Clear(); // Limpia todas las filas existentes en el DataGridView antes de cargar nuevos datos.
                var repartidores = logica.ObtenerTodos(); // Obtiene todos los repartidores utilizando el metodo de la capa de logica de negocio.

                foreach (var repartidor in repartidores) // Itera sobre cada objeto de repartidor obtenido.
                {
                    dataGridView1.Rows.Add( // Agrega una nueva fila al DataGridView con los datos del repartidor actual.
                        repartidor.Identificacion, // Celda para la identificacion del repartidor.
                        repartidor.Nombre, // Celda para el nombre del repartidor.
                        repartidor.PrimerApellido, // Celda para el primer apellido del repartidor.
                        repartidor.SegundoApellido, // Celda para el segundo apellido del repartidor.
                        repartidor.FechaNacimiento.ToString("dd/MM/yyyy"), // Celda para la fecha de nacimiento, formateada como dia/mes/ano.
                        repartidor.FechaContratacion.ToString("dd/MM/yyyy"), // Celda para la fecha de contratacion, formateada como dia/mes/ano.
                        repartidor.Activo ? "Si" : "No" // Celda para el estado activo del repartidor, mostrando "Si" si es true, "No" si es false.
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

