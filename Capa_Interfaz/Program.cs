//* [UNED Perez Zeledon]
//* II Cuatrimestre 2025
//* Sistema de Gestion de Pedidos
//* [Javier Rojas Cordero]
//* Fecha: 27/05/2025

using System; // Permite usar funcionalidades basicas del sistema, como tipos de datos y excepciones.
using System.Windows.Forms; // Proporciona clases para crear aplicaciones de Windows Forms.

namespace Capa_Interfaz // Define el espacio de nombres para la capa de interfaz de usuario.
{
    static class Program // Declara la clase estatica Program, que contiene el punto de entrada principal de la aplicacion.
    {
        /// <summary>
        /// Punto de entrada principal para la aplicacion. // Comentario de resumen para el metodo Main.
        /// </summary>
        [STAThread] // Atributo que indica que el hilo de la aplicacion debe ser un hilo de apartamento unico (Single Threaded Apartment). Esto es comun para aplicaciones Windows Forms.
        static void Main() // Define el metodo Main, que es el punto de entrada principal de la aplicacion.
        {
            Application.EnableVisualStyles(); // Habilita los estilos visuales para la aplicacion, permitiendo que los controles se dibujen con el estilo del sistema operativo.
            Application.SetCompatibleTextRenderingDefault(false); // Establece el modo predeterminado de renderizado de texto para que sea compatible con las versiones anteriores de GDI+.
            Application.Run(new FrmMenuPrincipal()); // Inicia el bucle de mensajes de la aplicacion y muestra el formulario FrmMenuPrincipal como el formulario principal.
        }
    }
}
//Como referencias se utilizaron los libros (Como programar en C#, Harvey M. Deitel), (Guia de Estudio, Programacion Avanzada, Carlos H. Hernandez Alvarado, como tambien las tutorias del curso)