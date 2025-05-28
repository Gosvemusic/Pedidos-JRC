using Capa_Acceso_Datos;
using Capa_Entidades;
using System;

namespace Capa_Log_Negocio
{
    public class LogArticulo
    {
        private DatosArticulo datos = new DatosArticulo();

        public string Insertar(ArticuloEntidad articulo)
        {
            try
            {
                // Validaciones
                if (articulo.Id <= 0)
                    return "El ID debe ser mayor a cero";

                if (string.IsNullOrWhiteSpace(articulo.Nombre))
                    return "El nombre es requerido";

                if (articulo.TipoArticulo == null)
                    return "Debe seleccionar un tipo de artículo";

                if (articulo.Valor <= 0)
                    return "El valor debe ser mayor a cero";

                if (articulo.Inventario < 0)
                    return "El inventario no puede ser negativo";

                if (datos.ExisteId(articulo.Id))
                    return "Ya existe un artículo con ese ID";

                if (datos.EstaLleno())
                    return "No se pueden ingresar más registros";

                bool resultado = datos.Insertar(articulo);
                return resultado ? "El registro se ha ingresado correctamente" : "Error al insertar el registro";
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }

        public ArticuloEntidad[] ObtenerTodos()
        {
            return datos.ObtenerTodos();
        }

        public ArticuloEntidad[] ObtenerActivos()
        {
            return datos.ObtenerActivos();
        }

        public void ActualizarInventario(int idArticulo, int cantidadRestar)
        {
            datos.ActualizarInventario(idArticulo, cantidadRestar);
        }
    }
}

