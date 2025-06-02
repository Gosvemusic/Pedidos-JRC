//* [UNED Perez Zeledon]
//* II Cuatrimestre 2025
//* Sistema de Gestion de Pedidos
//* [Javier Rojas Cordero]
//* Fecha: 27/05/2025

using System.Text; // Importa el espacio de nombres para trabajar con codificaciones de texto.
using System.Threading.Tasks; // Importa el espacio de nombres para manejar operaciones asincronas.
using System.Windows.Forms; // Importa el espacio de nombres para las clases de la interfaz grafica de Windows Forms.
using Capa_Log_Negocio; // Importa el espacio de nombres Capa_Log_Negocio para acceder a la logica de negocio.
using System; // Importa el espacio de nombres System para funcionalidades basicas como el manejo de excepciones y tipos de fecha.

namespace Capa_Interfaz // Define el espacio de nombres para la capa de interfaz de usuario de la aplicacion.
{
    public partial class FrmConsultaCliente : Form // Declara la clase FrmConsultaCliente, que es un formulario de Windows Forms y permite consultas de clientes.
    {
        private LogCliente logica = new LogCliente(); // Crea una instancia privada de LogCliente para interactuar con la logica de negocio de clientes.

        public FrmConsultaCliente() // Constructor de la clase FrmConsultaCliente.
        {
            InitializeComponent(); // Llama al metodo generado automaticamente para inicializar los componentes visuales del formulario.
            ConfigurarDataGridView(); // Llama a un metodo para configurar las columnas y propiedades del DataGridView.
            CargarDatos(); // Llama a un metodo para cargar los datos de los clientes en el DataGridView al iniciar el formulario.
        }

        private void ConfigurarDataGridView() // Metodo privado para configurar las columnas del DataGridView.
        {
            // Limpiar columnas existentes // Elimina cualquier columna preexistente en el DataGridView.
            dataGridView1.Columns.Clear();

            // Agregar columnas // Anade las columnas necesarias con sus nombres internos y encabezados visibles.
            dataGridView1.Columns.Add("Identificacion", "Identificacion"); // Columna para la identificacion del cliente.
            dataGridView1.Columns.Add("Nombre", "Nombre"); // Columna para el nombre del cliente.
            dataGridView1.Columns.Add("PrimerApellido", "Primer Apellido"); // Columna para el primer apellido del cliente.
            dataGridView1.Columns.Add("SegundoApellido", "Segundo Apellido"); // Columna para el segundo apellido del cliente.
            dataGridView1.Columns.Add("FechaNacimiento", "Fecha de Nacimiento"); // Columna para la fecha de nacimiento del cliente.
            dataGridView1.Columns.Add("Activo", "Activo"); // Columna para indicar si el cliente esta activo o no.

            // Configurar ancho de columnas // Ajusta el modo de tamano de las columnas.
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Las columnas se ajustaran automaticamente para llenar el ancho disponible del DataGridView.
        }

        private void CargarDatos() // Metodo privado para cargar los datos de los clientes en el DataGridView.
        {
            try // Inicia un bloque try para manejar posibles excepciones durante la carga de datos.
            {
                dataGridView1.Rows.Clear(); // Limpia todas las filas existentes en el DataGridView antes de cargar nuevos datos.
                var clientes = logica.ObtenerTodos(); // Obtiene todos los clientes utilizando el metodo ObtenerTodos de la capa de logica de negocio.

                foreach (var cliente in clientes) // Itera sobre cada cliente obtenido.
                {
                    dataGridView1.Rows.Add( // Agrega una nueva fila al DataGridView con los datos del cliente actual.
                        cliente.Identificacion, // Columna para la identificacion.
                        cliente.Nombre, // Columna para el nombre.
                        cliente.PrimerApellido, // Columna para el primer apellido.
                        cliente.SegundoApellido, // Columna para el segundo apellido.
                        cliente.FechaNacimiento.ToString("dd/MM/yyyy"), // Columna para la fecha de nacimiento, formateada como dia/mes/ano.
                        cliente.Activo ? "Si" : "No" // Columna para el estado activo, mostrando "Si" si es true, "No" si es false.
                    );
                }
            }
            catch (Exception ex) // Captura cualquier excepcion generica que pueda ocurrir durante la carga de datos.
            {
                MessageBox.Show("Error al cargar los datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // Muestra un cuadro de mensaje de error al usuario.
            }
        }
    }
}
//Como referencias se utilizaron los libros (Como programar en C#, Harvey M. Deitel), (Guia de Estudio, Programacion Avanzada, Carlos H. Hernandez Alvarado, como tambien las tutorias del curso)

