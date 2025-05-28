using Capa_Acceso_Datos;
using Capa_Entidades;
using System;

namespace Capa_Log_Negocio
{
    public class LogRepartidor
    {
        private DatosRepartidor datos = new DatosRepartidor();

        public string Insertar(RepartidorEntidad repartidor)
        {
            try
            {
                // Validaciones
                if (repartidor.Identificacion <= 0)
                    return "La identificación debe ser mayor a cero";

                if (string.IsNullOrWhiteSpace(repartidor.Nombre))
                    return "El nombre es requerido";

                if (string.IsNullOrWhiteSpace(repartidor.PrimerApellido))
                    return "El primer apellido es requerido";

                if (string.IsNullOrWhiteSpace(repartidor.SegundoApellido))
                    return "El segundo apellido es requerido";

                // Validar mayor de edad
                int edad = DateTime.Today.Year - repartidor.FechaNacimiento.Year;
                if (repartidor.FechaNacimiento.Date > DateTime.Today.AddYears(-edad))
                    edad--;

                if (edad < 18)
                    return "El repartidor debe ser mayor de edad";

                if (repartidor.FechaContratacion > DateTime.Today)
                    return "La fecha de contratación no puede ser mayor a hoy";

                if (datos.ExisteIdentificacion(repartidor.Identificacion))
                    return "Ya existe un repartidor con esa identificación";

                if (datos.EstaLleno())
                    return "No se pueden ingresar más registros";

                bool resultado = datos.Insertar(repartidor);
                return resultado ? "El registro se ha ingresado correctamente" : "Error al insertar el registro";
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }

        public RepartidorEntidad[] ObtenerTodos()
        {
            return datos.ObtenerTodos();
        }

        public RepartidorEntidad[] ObtenerActivos()
        {
            return datos.ObtenerActivos();
        }
    }
}
