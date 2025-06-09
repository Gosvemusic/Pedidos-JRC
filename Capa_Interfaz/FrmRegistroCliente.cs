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
using Capa_Entidades; // Importa el espacio de nombres Capa_Entidades para acceder a las clases de entidad (modelos de datos).
using Capa_Log_Negocio; // Importa el espacio de nombres Capa_Log_Negocio para acceder a la logica de negocio.

namespace Capa_Interfaz // Define el espacio de nombres para la capa de interfaz de usuario de la aplicacion.
{
    public partial class FrmRegistroCliente : Form // Declara la clase publica FrmRegistroCliente, que representa el formulario para registrar clientes. Es una clase parcial, lo que permite que su definicion este dividida en varios archivos (uno para la logica y otro para el diseño).
    {
        private LogCliente logica = new LogCliente(); // Crea una instancia privada de LogCliente para interactuar con la logica de negocio de los clientes.

        public FrmRegistroCliente() // Constructor de la clase FrmRegistroCliente.
        {
            InitializeComponent(); // Llama al metodo generado automaticamente por el diseñador para inicializar y configurar todos los componentes visuales del formulario.
            ConfigurarComboActivo(); // Llama a un metodo personalizado para configurar el ComboBox de estado "Activo".
        }

        private void ConfigurarComboActivo() // Metodo privado para configurar el ComboBox de estado "Activo".
        {
            cboActivo.Items.Clear(); // Limpia cualquier elemento existente en el ComboBox.
            cboActivo.Items.Add("Si"); // Agrega la opcion "Si" al ComboBox.
            cboActivo.Items.Add("No"); // Agrega la opcion "No" al ComboBox.
            cboActivo.DropDownStyle = ComboBoxStyle.DropDownList; // Establece el estilo del ComboBox para que sea una lista desplegable y no se pueda editar el texto.
            cboActivo.SelectedIndex = 0; // Establece "Si" como la opcion seleccionada por defecto (indice 0).
        }

        private void label6_Click(object sender, EventArgs e) // Manejador de eventos para el clic del 'label6'.
        {
            
        }

        private void bnGuardar_Click(object sender, EventArgs e) // Manejador de eventos para el clic del boton "Guardar".
        {
            try // Inicia un bloque try para manejar posibles excepciones durante el proceso de guardado.
            {
                ClienteEntidad cliente = new ClienteEntidad(); // Crea una nueva instancia de la clase ClienteEntidad para almacenar los datos del formulario.

                // Validar identificacion numerica // Comentario que indica la validacion de la identificacion.
                if (!int.TryParse(txtIdentificacion.Text, out int identificacion)) // Intenta convertir el texto del campo Identificacion a un numero entero.
                {
                    MessageBox.Show("La identificacion debe ser un numero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // Muestra un mensaje de error si la conversion falla.
                    return; // Sale del metodo si la validacion falla.
                }

                cliente.Identificacion = identificacion; // Asigna la identificacion validada al objeto cliente.
                cliente.Nombre = txtNombre.Text; // Asigna el nombre del campo de texto al objeto cliente.
                cliente.PrimerApellido = txtPrimerApellido.Text; // Asigna el primer apellido del campo de texto al objeto cliente.
                cliente.SegundoApellido = txtSegundoApellido.Text; // Asigna el segundo apellido del campo de texto al objeto cliente.
                cliente.FechaNacimiento = dtpFechaNacimiento.Value; // Asigna la fecha seleccionada en el control DateTimePicker al objeto cliente.
                cliente.Activo = cboActivo.SelectedItem.ToString() == "Si"; // Asigna el estado "Activo" basado en la seleccion del ComboBox (Si es "Si", es true; de lo contrario, es false).

                string resultado = logica.Insertar(cliente); // Llama al metodo Insertar de la logica de negocio de cliente y guarda el resultado.

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
            txtIdentificacion.Clear(); // Limpia el texto del campo Identificacion.
            txtNombre.Clear(); // Limpia el texto del campo Nombre.
            txtPrimerApellido.Clear(); // Limpia el texto del campo Primer Apellido.
            txtSegundoApellido.Clear(); // Limpia el texto del campo Segundo Apellido.
            dtpFechaNacimiento.Value = DateTime.Now; // Restablece la fecha del DateTimePicker a la fecha y hora actual.
            cboActivo.SelectedIndex = 0; // Restablece la seleccion del ComboBox de estado activo a la primera opcion ("Si").
            txtIdentificacion.Focus(); // Pone el foco en el campo Identificacion, listo para una nueva entrada.
        }

        private void cboActivo_SelectedIndexChanged(object sender, EventArgs e) // Manejador de eventos para el cambio de seleccion en el ComboBox 'cboActivo'.
        {
            // Este metodo esta vacio, lo que significa que no hay logica especifica implementada para el cambio de seleccion en este momento.
        }
    }
}
//Como referencias se utilizaron los libros (Como programar en C#, Harvey M. Deitel), (Guia de Estudio, Programacion Avanzada, Carlos H. Hernandez Alvarado, como tambien las tutorias del curso)

