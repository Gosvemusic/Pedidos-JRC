using Capa_Acceso_Datos;
using Capa_Entidades;
using System;

namespace Capa_Log_Negocio
{
    public class LogCliente
    {
        private DatosCliente datos = new DatosCliente();

        public string Insertar(ClienteEntidad cliente)
        {
            try
            {
                // Validaciones
                if (cliente.Identificacion <= 0)
                    return "La identificación debe ser mayor a cero";

                if (string.IsNullOrWhiteSpace(cliente.Nombre))
                    return "El nombre es requerido";

                if (string.IsNullOrWhiteSpace(cliente.PrimerApellido))
                    return "El primer apellido es requerido";

                if (string.IsNullOrWhiteSpace(cliente.SegundoApellido))
                    return "El segundo apellido es requerido";

                if (cliente.FechaNacimiento >= DateTime.Today)
                    return "La fecha de nacimiento debe ser anterior a hoy";

                if (datos.ExisteIdentificacion(cliente.Identificacion))
                    return "Ya existe un cliente con esa identificación";

                if (datos.EstaLleno())
                    return "No se pueden ingresar más registros";

                bool resultado = datos.Insertar(cliente);
                return resultado ? "El registro se ha ingresado correctamente" : "Error al insertar el registro";
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }

        public ClienteEntidad[] ObtenerTodos()
        {
            return datos.ObtenerTodos();
        }

        public ClienteEntidad[] ObtenerActivos()
        {
            return datos.ObtenerActivos();
        }
    }
}