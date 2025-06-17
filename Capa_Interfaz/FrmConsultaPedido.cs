//* [UNED Perez Zeledon]
//* II Cuatrimestre 2025
//* Sistema de Gestion de Pedidos
//* [Javier Rojas Cordero]
//* Fecha: 27/05/2025

using System; // Importa el espacio de nombres System para acceder a funcionalidades basicas como el manejo de excepciones y tipos de fecha.
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
    public partial class FrmConsultaPedido : Form // Declara la clase publica FrmConsultaPedido, que representa un formulario de consulta de pedidos. Es una clase parcial, lo que significa que parte de su definicion esta en otro archivo (normalmente generado por el diseñador).
    {
        private LogPedido logica = new LogPedido(); // Crea una instancia privada de LogPedido para interactuar con la logica de negocio de pedidos.
        private DataGridView dgvEncabezados; // Declara un control DataGridView para mostrar los encabezados de los pedidos.
        private DataGridView dgvDetalles; // Declara un control DataGridView para mostrar los detalles de un pedido seleccionado.
        private Label lblEncabezados; // Declara un control Label para etiquetar el DataGridView de encabezados.
        private Label lblDetalles; // Declara un control Label para etiquetar el DataGridView de detalles.

        public FrmConsultaPedido() // Constructor de la clase FrmConsultaPedido.
        {
            InitializeComponent(); // Llama al metodo generado automaticamente por el diseñador para inicializar los componentes visuales del formulario.
            ConfigurarFormulario(); // Llama a un metodo personalizado para configurar la disposicion y el contenido del formulario.
        }

        private void ConfigurarFormulario() // Metodo privado para configurar el formulario y sus controles dinamicamente.
        {
            // Ocultar o eliminar el DataGridView del designer // Comentario que explica la eliminacion del control de diseñador.
            if (dataGridView1 != null) // Verifica si el DataGridView preexistente (del diseñador) no es nulo.
            {
                this.Controls.Remove(dataGridView1); // Remueve el control DataGridView del formulario.
                dataGridView1.Dispose(); // Libera los recursos del control DataGridView removido.
            }

            // Configurar el formulario // Comentario que indica la configuracion general del formulario.
            this.Text = "Consulta de Pedidos"; // Establece el texto del titulo del formulario.
            this.Size = new Size(1000, 700); // Establece el tamaño del formulario en pixeles.
            this.StartPosition = FormStartPosition.CenterScreen; // Posiciona el formulario en el centro de la pantalla al iniciar.

            // Crear y configurar controles // Comentario que indica la creacion y configuracion de los controles de UI.
            lblEncabezados = new Label(); // Instancia un nuevo objeto Label para el titulo de los encabezados.
            lblEncabezados.Text = "Encabezados de Pedidos"; // Establece el texto del label.
            lblEncabezados.Location = new Point(12, 12); // Establece la posicion del label en el formulario.
            lblEncabezados.Size = new Size(200, 20); // Establece el tamaño del label.
            lblEncabezados.Font = new Font("Arial", 10, FontStyle.Bold); // Establece la fuente y estilo del texto del label.

            dgvEncabezados = new DataGridView(); // Instancia un nuevo objeto DataGridView para los encabezados de pedidos.
            dgvEncabezados.Location = new Point(12, 35); // Establece la posicion del DataGridView.
            dgvEncabezados.Size = new Size(960, 250); // Establece el tamaño del DataGridView.
            dgvEncabezados.AllowUserToAddRows = false; // Deshabilita la opcion de agregar filas directamente desde la interfaz.
            dgvEncabezados.ReadOnly = true; // Hace que el DataGridView sea de solo lectura.
            dgvEncabezados.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Permite la seleccion de filas completas.
            dgvEncabezados.MultiSelect = false; // Deshabilita la seleccion multiple de filas.
            dgvEncabezados.SelectionChanged += dgvEncabezados_SelectionChanged; // Asocia el evento SelectionChanged con un metodo manejador.

            lblDetalles = new Label(); // Instancia un nuevo objeto Label para el titulo de los detalles.
            lblDetalles.Text = "Detalles del Pedido"; // Establece el texto del label.
            lblDetalles.Location = new Point(12, 300); // Establece la posicion del label.
            lblDetalles.Size = new Size(200, 20); // Establece el tamaño del label.
            lblDetalles.Font = new Font("Arial", 10, FontStyle.Bold); // Establece la fuente y estilo del texto del label.

            dgvDetalles = new DataGridView(); // Instancia un nuevo objeto DataGridView para los detalles del pedido.
            dgvDetalles.Location = new Point(12, 323); // Establece la posicion del DataGridView.
            dgvDetalles.Size = new Size(960, 250); // Establece el tamaño del DataGridView.
            dgvDetalles.AllowUserToAddRows = false; // Deshabilita la opcion de agregar filas.
            dgvDetalles.ReadOnly = true; // Hace que el DataGridView sea de solo lectura.

            // Agregar controles al formulario // Comentario que indica la adicion de controles al formulario.
            this.Controls.Add(lblEncabezados); // Añade el label de encabezados al formulario.
            this.Controls.Add(dgvEncabezados); // Añade el DataGridView de encabezados al formulario.
            this.Controls.Add(lblDetalles); // Añade el label de detalles al formulario.
            this.Controls.Add(dgvDetalles); // Añade el DataGridView de detalles al formulario.

            // Configurar columnas // Comentario que indica la configuracion de las columnas de ambos DataGridViews.
            ConfigurarDataGridViews(); // Llama al metodo para definir las columnas de ambos DataGridViews.

            // Cargar datos // Comentario que indica la carga inicial de datos.
            CargarDatos(); // Llama al metodo para cargar los datos en los DataGridViews.
        }

        private void ConfigurarDataGridViews() // Metodo privado para definir las columnas de ambos DataGridViews.
        {
            // Configurar columnas del grid de encabezados // Comentario para la configuracion de las columnas de encabezados.
            dgvEncabezados.Columns.Clear(); // Limpia cualquier columna existente en el DataGridView de encabezados.
            dgvEncabezados.Columns.Add("NumeroPedido", "Numero de Pedido"); // Agrega la columna para el numero de pedido.
            dgvEncabezados.Columns.Add("FechaPedido", "Fecha de Pedido"); // Agrega la columna para la fecha del pedido.
            dgvEncabezados.Columns.Add("ClienteId", "Cliente ID"); // Agrega la columna para el ID del cliente.
            dgvEncabezados.Columns.Add("ClienteNombre", "Nombre Cliente"); // Agrega la columna para el nombre del cliente.
            dgvEncabezados.Columns.Add("ClientePrimerApellido", "Primer Apellido"); // Agrega la columna para el primer apellido del cliente.
            dgvEncabezados.Columns.Add("ClienteSegundoApellido", "Segundo Apellido"); // Agrega la columna para el segundo apellido del cliente.
            dgvEncabezados.Columns.Add("RepartidorId", "Repartidor ID"); // Agrega la columna para el ID del repartidor.
            dgvEncabezados.Columns.Add("RepartidorNombre", "Nombre Repartidor"); // Agrega la columna para el nombre del repartidor.
            dgvEncabezados.Columns.Add("RepartidorPrimerApellido", "Primer Apellido"); // Agrega la columna para el primer apellido del repartidor.
            dgvEncabezados.Columns.Add("RepartidorSegundoApellido", "Segundo Apellido"); // Agrega la columna para el segundo apellido del repartidor.
            dgvEncabezados.Columns.Add("Direccion", "Direccion"); // Agrega la columna para la direccion de entrega.

            // Ajustar tamaño de columnas // Comentario para el ajuste de tamaño de columnas de encabezados.
            foreach (DataGridViewColumn col in dgvEncabezados.Columns) // Itera sobre cada columna en el DataGridView de encabezados.
            {
                col.Width = 100; // Establece un ancho fijo de 100 pixeles para la mayoria de las columnas.
            }
            dgvEncabezados.Columns["Direccion"].Width = 150; // Establece un ancho especifico de 150 pixeles para la columna "Direccion".

            // Configurar columnas del grid de detalles // Comentario para la configuracion de las columnas de detalles.
            dgvDetalles.Columns.Clear(); // Limpia cualquier columna existente en el DataGridView de detalles.
            dgvDetalles.Columns.Add("ArticuloId", "ID Articulo"); // Agrega la columna para el ID del articulo en el detalle.
            dgvDetalles.Columns.Add("ArticuloNombre", "Nombre Articulo"); // Agrega la columna para el nombre del articulo en el detalle.
            dgvDetalles.Columns.Add("TipoArticulo", "Tipo de Articulo"); // Agrega la columna para el tipo de articulo en el detalle.
            dgvDetalles.Columns.Add("Cantidad", "Cantidad"); // Agrega la columna para la cantidad del articulo en el detalle.
            dgvDetalles.Columns.Add("Monto", "Monto"); // Agrega la columna para el monto total del detalle.

            dgvDetalles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Ajusta el tamaño de las columnas de detalles para que llenen el ancho disponible.
        }

        private void CargarDatos() // Metodo privado para cargar los datos de los encabezados de pedidos.
        {
            try // Inicia un bloque try para manejar posibles excepciones.
            {
                dgvEncabezados.Rows.Clear(); // Limpia todas las filas existentes en el DataGridView de encabezados.
                var pedidos = logica.ObtenerTodos(); // Obtiene todos los pedidos desde la capa de logica de negocio.

                foreach (var pedido in pedidos) // Itera sobre cada objeto de pedido.
                {
                    dgvEncabezados.Rows.Add( // Agrega una nueva fila al DataGridView de encabezados con los datos del pedido.
                        pedido.NumeroPedido, // Numero del pedido.
                        pedido.FechaPedido.ToString("dd/MM/yyyy"), // Fecha del pedido formateada.
                        pedido.Cliente.Identificacion, // Identificacion del cliente.
                        pedido.Cliente.Nombre, // Nombre del cliente.
                        pedido.Cliente.PrimerApellido, // Primer apellido del cliente.
                        pedido.Cliente.SegundoApellido, // Segundo apellido del cliente.
                        pedido.Repartidor.Identificacion, // Identificacion del repartidor.
                        pedido.Repartidor.Nombre, // Nombre del repartidor.
                        pedido.Repartidor.PrimerApellido, // Primer apellido del repartidor.
                        pedido.Repartidor.SegundoApellido, // Segundo apellido del repartidor.
                        pedido.Direccion // Direccion de entrega.
                    );
                }

                // Limpiar detalles al inicio // Comentario que indica que los detalles se limpian al inicio.
                dgvDetalles.Rows.Clear(); // Limpia todas las filas del DataGridView de detalles.
            }
            catch (Exception ex) // Captura cualquier excepcion generica.
            {
                MessageBox.Show("Error al cargar los datos: " + ex.Message, "Error", // Muestra un cuadro de mensaje de error al usuario.
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvEncabezados_SelectionChanged(object sender, EventArgs e) // Manejador de eventos que se dispara cuando cambia la seleccion de fila en dgvEncabezados.
        {
            try // Inicia un bloque try para manejar posibles excepciones.
            {
                dgvDetalles.Rows.Clear(); // Limpia las filas del DataGridView de detalles antes de cargar nuevos detalles.

                if (dgvEncabezados.CurrentRow != null && dgvEncabezados.CurrentRow.Index >= 0) // Verifica si hay una fila seleccionada y su indice es valido.
                {
                    int numeroPedido = Convert.ToInt32(dgvEncabezados.CurrentRow.Cells["NumeroPedido"].Value); // Obtiene el numero de pedido de la fila seleccionada.
                    var detalles = logica.ObtenerDetallesPorPedido(numeroPedido); // Obtiene los detalles de ese pedido desde la logica de negocio.

                    foreach (var detalle in detalles) // Itera sobre cada detalle de pedido.
                    {
                        dgvDetalles.Rows.Add( // Agrega una nueva fila al DataGridView de detalles.
                            detalle.Articulo.Id, // ID del articulo.
                            detalle.Articulo.Nombre, // Nombre del articulo.
                            detalle.Articulo.TipoArticulo.Nombre, // Nombre del tipo de articulo.
                            detalle.Cantidad, // Cantidad del articulo.
                            detalle.Monto.ToString("C") // Monto del detalle, formateado como moneda.
                        );
                    }
                }
            }
            catch (Exception ex) // Captura cualquier excepcion generica.
            {
                MessageBox.Show("Error al cargar los detalles: " + ex.Message, "Error", // Muestra un cuadro de mensaje de error al usuario.
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) 
        {
            
        }
    }
}
//Como referencias se utilizaron los libros (Como programar en C#, Harvey M. Deitel), (Guia de Estudio, Programacion Avanzada, Carlos H. Hernandez Alvarado, como tambien las tutorias del curso)
