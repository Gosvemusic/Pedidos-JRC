//* [UNED Perez Zeledon]
//* II Cuatrimestre 2025
//* Sistema de Gestion de Pedidos
//* [Javier Rojas Cordero]
//* Fecha: 27/05/2025


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text; // Permite el manejo de codificacion de caracteres.
using System.Threading.Tasks; // Permite el uso de programacion asincrona.
using System.Windows.Forms; // Proporciona clases para crear aplicaciones de Windows Forms.
using Capa_Entidades; // Importa las clases de la capa de entidades del proyecto.
using Capa_Log_Negocio; // Importa las clases de la capa de logica de negocio del proyecto.

namespace Capa_Interfaz // Define el espacio de nombres para la capa de interfaz de usuario.
{
    public partial class FrmRegistroRepartidor : Form // Declara la clase FrmRegistroRepartidor, que hereda de Form.
    {
        private LogRepartidor logica = new LogRepartidor(); // Crea una instancia de la clase LogRepartidor para la logica de negocio.

        public FrmRegistroRepartidor() // Constructor de la clase FrmRegistroRepartidor.
        {
            InitializeComponent(); // Inicializa los componentes visuales del formulario.
            ConfigurarComboActivo(); // Llama a un metodo para configurar el ComboBox de estado activo.
        }

        private void ConfigurarComboActivo() // Metodo para configurar las opciones del ComboBox de estado activo.
        {
            cboActivo.Items.Clear(); // Limpia cualquier item existente en el ComboBox.
            cboActivo.Items.Add("Si"); // Agrega la opcion "Si".
            cboActivo.Items.Add("No"); // Agrega la opcion "No".
            cboActivo.SelectedIndex = 0; // Por defecto selecciona "Si".
        }

        private void btnGuardar_Click(object sender, EventArgs e) // Evento Click del boton "Guardar".
        {
            try // Bloque try-catch para manejar posibles excepciones.
            {
                RepartidorEntidad repartidor = new RepartidorEntidad(); // Crea una nueva instancia de la entidad RepartidorEntidad.

                // Validar identificacion numerica.
                if (!int.TryParse(txtIdentificacion.Text, out int identificacion)) // Intenta convertir el texto de identificacion a un entero.
                {
                    // Muestra un mensaje de error si la identificacion no es un numero.
                    MessageBox.Show("La identificacion debe ser un numero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Sale del metodo.
                }

                repartidor.Identificacion = identificacion; // Asigna la identificacion al objeto repartidor.
                repartidor.Nombre = txtNombre.Text; // Asigna el nombre al objeto repartidor.
                repartidor.PrimerApellido = txtPrimerApellido.Text; // Asigna el primer apellido al objeto repartidor.
                repartidor.SegundoApellido = txtSegundoApellido.Text; // Asigna el segundo apellido al objeto repartidor.
                repartidor.FechaNacimiento = dtpFechaNacimiento.Value; // Asigna la fecha de nacimiento al objeto repartidor.
                repartidor.FechaContratacion = dtpFechaContratacion.Value; // Asigna la fecha de contratacion al objeto repartidor.
                repartidor.Activo = cboActivo.Text == "Si"; // Asigna el estado activo basado en la seleccion del ComboBox.

                string resultado = logica.Insertar(repartidor); // Llama al metodo de logica de negocio para insertar el repartidor.

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
            txtIdentificacion.Clear(); // Limpia el campo de texto de identificacion.
            txtNombre.Clear(); // Limpia el campo de texto de nombre.
            txtPrimerApellido.Clear(); // Limpia el campo de texto de primer apellido.
            txtSegundoApellido.Clear(); // Limpia el campo de texto de segundo apellido.
            dtpFechaNacimiento.Value = DateTime.Now; // Restablece la fecha de nacimiento a la fecha y hora actual.
            dtpFechaContratacion.Value = DateTime.Now; // Restablece la fecha de contratacion a la fecha y hora actual.
            cboActivo.SelectedIndex = -1; // Deselecciona cualquier item en el ComboBox de estado activo.
            txtIdentificacion.Focus(); // Pone el foco en el campo de identificacion.
        }

        private void cboActivo_SelectedIndexChanged(object sender, EventArgs e) // Evento SelectedIndexChanged del ComboBox de estado activo.
        {
            // Este metodo esta vacio, lo que significa que no hay una logica especifica
            // que se ejecute cuando cambia la seleccion del estado activo en el ComboBox.
        }
    }
}
//Como referencias se utilizaron los libros (Como programar en C#, Harvey M. Deitel), (Guia de Estudio, Programacion Avanzada, Carlos H. Hernandez Alvarado, como tambien las tutorias del curso)

