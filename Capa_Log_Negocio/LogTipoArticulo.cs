using Capa_Acceso_Datos;
using Capa_Entidades;
using System;

namespace Capa_Log_Negocio
{
    public class LogTipoArticulo
    {
        private DatosTipoArticulo datos = new DatosTipoArticulo();

        public string Insertar(TipoArticuloEntidad tipo)
        {
            try
            {
                // Validaciones
                if (tipo.Id <= 0)
                    return "El ID debe ser mayor a cero";

                if (string.IsNullOrWhiteSpace(tipo.Nombre))
                    return "El nombre es requerido";

                if (string.IsNullOrWhiteSpace(tipo.Descripcion))
                    return "La descripción es requerida";

                if (datos.ExisteId(tipo.Id))
                    return "Ya existe un tipo de artículo con ese ID";

                if (datos.EstaLleno())
                    return "No se pueden ingresar más registros";

                bool resultado = datos.Insertar(tipo);
                return resultado ? "El registro se ha ingresado correctamente" : "Error al insertar el registro";
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }

        public TipoArticuloEntidad[] ObtenerTodos()
        {
            return datos.ObtenerTodos();
        }
    }
}
