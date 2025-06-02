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
using Capa_Entidades; // Importa el espacio de nombres Capa_Entidades para acceder a las clases de entidad (modelos de datos).
using Capa_Log_Negocio; // Importa el espacio de nombres Capa_Log_Negocio para acceder a la logica de negocio.

namespace Capa_Interfaz // Define el espacio de nombres para la capa de interfaz de usuario de la aplicacion.
{
    public partial class FrmRegistroArticulo : Form // Declara la clase publica FrmRegistroArticulo, que representa el formulario para registrar articulos. Es una clase parcial, lo que permite que su definicion este dividida en varios archivos (uno para la logica y otro para el diseño).
    {
        private LogArticulo logicaArticulo = new LogArticulo(); // Crea una instancia privada de LogArticulo para interactuar con la logica de negocio de los articulos.
        private LogTipoArticulo logicaTipo = new LogTipoArticulo(); // Crea una instancia privada de LogTipoArticulo para interactuar con la logica de negocio de los tipos de articulo.

        public FrmRegistroArticulo() // Constructor de la clase FrmRegistroArticulo.
        {
            InitializeComponent(); // Llama al metodo generado automaticamente por el diseñador para inicializar y configurar todos los componentes visuales del formulario.
            CargarTiposArticulo(); // Llama a un metodo personalizado para cargar los tipos de articulo en un ComboBox.
            ConfigurarComboActivo(); // Llama a un metodo personalizado para configurar el ComboBox de estado "Activo".
        }

        private void CargarTiposArticulo() // Metodo privado para cargar los tipos de articulo desde la logica de negocio y mostrarlos en un ComboBox.
        {
            try // Inicia un bloque try para manejar posibles excepciones durante la carga de datos.
            {
                var tipos = logicaTipo.ObtenerTodos(); // Obtiene todos los tipos de articulo utilizando el metodo de la logica de negocio.
                cboTipoArticulo.DisplayMember = "Nombre"; // Establece la propiedad "Nombre" de TipoArticuloEntidad como el texto visible en el ComboBox.
                cboTipoArticulo.ValueMember = "Id"; // Establece la propiedad "Id" de TipoArticuloEntidad como el valor real asociado a cada elemento del ComboBox.
                cboTipoArticulo.DataSource = tipos; // Asigna la lista de tipos de articulo como la fuente de datos del ComboBox.
            }
            catch (Exception ex) // Captura cualquier excepcion generica que pueda ocurrir.
            {
                MessageBox.Show("Error al cargar tipos de articulo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // Muestra un mensaje de error al usuario.
            }
        }

        private void ConfigurarComboActivo() // Metodo privado para configurar el ComboBox de estado "Activo".
        {
            cboActivo.Items.Clear(); // Limpia cualquier elemento existente en el ComboBox.
            cboActivo.Items.Add("Si"); // Agrega la opcion "Si" al ComboBox.
            cboActivo.Items.Add("No"); // Agrega la opcion "No" al ComboBox.
            cboActivo.SelectedIndex = 0; // Establece "Si" como la opcion seleccionada por defecto (indice 0).
        }

        private void btnGuardar_Click(object sender, EventArgs e) // Manejador de eventos para el clic del boton "Guardar".
        {
            try // Inicia un bloque try para manejar posibles excepciones durante el proceso de guardado.
            {
                ArticuloEntidad articulo = new ArticuloEntidad(); // Crea una nueva instancia de la clase ArticuloEntidad para almacenar los datos del formulario.

                // Validar ID numerico // Comentario que indica la validacion del ID.
                if (!int.TryParse(txtId.Text, out int id)) // Intenta convertir el texto del campo ID a un numero entero.
                {
                    MessageBox.Show("El ID debe ser un numero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // Muestra un mensaje de error si la conversion falla.
                    return; // Sale del metodo si la validacion falla.
                }

                // Validar valor numerico // Comentario que indica la validacion del valor.
                if (!double.TryParse(txtValor.Text, out double valor)) // Intenta convertir el texto del campo Valor a un numero de punto flotante.
                {
                    MessageBox.Show("El valor debe ser un numero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // Muestra un mensaje de error si la conversion falla.
                    return; // Sale del metodo si la validacion falla.
                }

                // Validar inventario numerico // Comentario que indica la validacion del inventario.
                if (!int.TryParse(txtInventario.Text, out int inventario)) // Intenta convertir el texto del campo Inventario a un numero entero.
                {
                    MessageBox.Show("El inventario debe ser un numero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // Muestra un mensaje de error si la conversion falla.
                    return; // Sale del metodo si la validacion falla.
                }

                articulo.Id = id; // Asigna el ID validado al objeto articulo.
                articulo.Nombre = txtNombre.Text; // Asigna el nombre del campo de texto al objeto articulo.
                articulo.TipoArticulo = (TipoArticuloEntidad)cboTipoArticulo.SelectedItem; // Asigna el tipo de articulo seleccionado en el ComboBox al objeto articulo. Se realiza un cast ya que SelectedItem devuelve un object.
                articulo.Valor = valor; // Asigna el valor validado al objeto articulo.
                articulo.Inventario = inventario; // Asigna la cantidad de inventario validada al objeto articulo.
                articulo.Activo = cboActivo.Text == "Si"; // Asigna el estado "Activo" basado en la seleccion del ComboBox (Si es "Si", es true; de lo contrario, es false).

                string resultado = logicaArticulo.Insertar(articulo); // Llama al metodo Insertar de la logica de negocio de articulo y guarda el resultado.

                if (resultado == "El registro se ha ingresado correctamente") // Verifica si el resultado de la insercion fue exitoso.
                {
                    MessageBox.Show(resultado, "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information); // Muestra un mensaje de exito al usuario.
                    LimpiarCampos(); // Llama al metodo para limpiar los campos del formulario.
                }
                else // Si el resultado no fue exitoso.
                {
                    MessageBox.Show(resultado, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); // Muestra un mensaje de advertencia o error al usuario.
                }
            }
            catch (Exception ex) // Captura cualquier excepcion generica que pueda ocurrir en el bloque try.
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // Muestra un mensaje de error general al usuario.
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e) // Manejador de eventos para el clic del boton "Limpiar".
        {
            LimpiarCampos(); // Llama al metodo para limpiar todos los campos del formulario.
        }

        private void LimpiarCampos() // Metodo privado para limpiar los controles del formulario.
        {
            txtId.Clear(); // Limpia el texto del campo ID.
            txtNombre.Clear(); // Limpia el texto del campo Nombre.
            cboTipoArticulo.SelectedIndex = -1; // Deselecciona cualquier elemento en el ComboBox de tipo de articulo.
            txtValor.Clear(); // Limpia el texto del campo Valor.
            txtInventario.Clear(); // Limpia el texto del campo Inventario.
            cboActivo.SelectedIndex = -1; // Deselecciona cualquier elemento en el ComboBox de estado activo.
            txtId.Focus(); // Pone el foco en el campo ID, listo para una nueva entrada.
        }
    }
}
//Como referencias se utilizaron los libros (Como programar en C#, Harvey M. Deitel), (Guia de Estudio, Programacion Avanzada, Carlos H. Hernandez Alvarado, como tambien las tutorias del curso)

