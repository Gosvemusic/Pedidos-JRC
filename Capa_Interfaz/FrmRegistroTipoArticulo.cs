//* [UNED Perez Zeledon]
//* II Cuatrimestre 2025
//* Sistema de Gestion de Pedidos
//* [Javier Rojas Cordero]
//* Fecha: 27/05/2025

using System; // Permite usar funcionalidades basicas del sistema, como tipos de datos y excepciones.
using System.Collections.Generic; // Permite el uso de colecciones genericas como List<T>.
using System.ComponentModel; // Proporciona clases para implementar componentes y controles.
using System.Data; // Permite el manejo de datos y conjuntos de datos.
using System.Drawing; // Proporciona acceso a funcionalidades graficas basicas.
using System.Linq; // Habilita consultas LINQ para colecciones de objetos.
using System.Text; // Permite el manejo de codificacion de caracteres.
using System.Threading.Tasks; // Permite el uso de programacion asincrona.
using System.Windows.Forms; // Proporciona clases para crear aplicaciones de Windows Forms.
using Capa_Entidades; // Importa las clases de la capa de entidades del proyecto.
using Capa_Log_Negocio; // Importa las clases de la capa de logica de negocio del proyecto.

namespace Capa_Interfaz // Define el espacio de nombres para la capa de interfaz de usuario.
{
    public partial class FrmRegistroTipoArticulo : Form // Declara la clase FrmRegistroTipoArticulo, que hereda de Form.
    {
        private LogTipoArticulo logica = new LogTipoArticulo(); // Crea una instancia de la clase LogTipoArticulo para la logica de negocio.

        public FrmRegistroTipoArticulo() // Constructor de la clase FrmRegistroTipoArticulo.
        {
            InitializeComponent(); // Inicializa los componentes visuales del formulario.
        }

        private void btnGuardar_Click(object sender, EventArgs e) // Evento Click del boton "Guardar".
        {
            try // Bloque try-catch para manejar posibles excepciones.
            {
                TipoArticuloEntidad tipo = new TipoArticuloEntidad(); // Crea una nueva instancia de la entidad TipoArticuloEntidad.

                // Validar ID numerico.
                if (!int.TryParse(txtId.Text, out int id)) // Intenta convertir el texto del ID a un entero.
                {
                    // Muestra un mensaje de error si el ID no es un numero.
                    MessageBox.Show("El ID debe ser un numero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Sale del metodo.
                }

                tipo.Id = id; // Asigna el ID al objeto tipo.
                tipo.Nombre = txtNombre.Text; // Asigna el nombre al objeto tipo.
                tipo.Descripcion = txtDescripcion.Text; // Asigna la descripcion al objeto tipo.

                string resultado = logica.Insertar(tipo); // Llama al metodo de logica de negocio para insertar el tipo de articulo.

                if (resultado == "El registro se ha ingresado correctamente") // Si el registro fue exitoso.
                {
                    // Muestra un mensaje de exito.
                    MessageBox.Show(resultado, "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarCampos(); // Llama al metodo para limpiar los campos del formulario.
                }
                else // Si hubo un problema al registrar.
                {
                    // Muestra un mensaje de advertencia con el resultado.
                    MessageBox.Show(resultado, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex) // Captura cualquier excepcion que ocurra.
            {
                // Muestra un mensaje de error detallado.
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e) // Evento Click del boton "Limpiar".
        {
            LimpiarCampos(); // Llama al metodo para limpiar los campos del formulario.
        }

        private void LimpiarCampos() // Metodo para limpiar todos los campos del formulario.
        {
            txtId.Clear(); // Limpia el campo de texto del ID.
            txtNombre.Clear(); // Limpia el campo de texto del nombre.
            txtDescripcion.Clear(); // Limpia el campo de texto de la descripcion.
            txtId.Focus(); // Pone el foco en el campo del ID.
        }
    }
}
//Como referencias se utilizaron los libros (Como programar en C#, Harvey M. Deitel), (Guia de Estudio, Programacion Avanzada, Carlos H. Hernandez Alvarado, como tambien las tutorias del curso)
