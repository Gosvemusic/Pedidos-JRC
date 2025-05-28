using Capa_Entidades;
using System;

namespace Capa_Acceso_Datos
{
    public class DatosArticulo
    {
        private static ArticuloEntidad[] articulos = new ArticuloEntidad[20];
        private static int contador = 0;

        public bool Insertar(ArticuloEntidad articulo)
        {
            try
            {
                if (contador >= articulos.Length)
                    return false;

                if (ExisteId(articulo.Id))
                    return false;

                articulos[contador] = articulo;
                contador++;
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool ExisteId(int id)
        {
            for (int i = 0; i < contador; i++)
            {
                if (articulos[i].Id == id)
                    return true;
            }
            return false;
        }

        public ArticuloEntidad[] ObtenerTodos()
        {
            ArticuloEntidad[] resultado = new ArticuloEntidad[contador];
            Array.Copy(articulos, resultado, contador);
            return resultado;
        }

        public ArticuloEntidad[] ObtenerActivos()
        {
            int count = 0;
            for (int i = 0; i < contador; i++)
            {
                if (articulos[i].Activo)
                    count++;
            }

            ArticuloEntidad[] activos = new ArticuloEntidad[count];
            int index = 0;
            for (int i = 0; i < contador; i++)
            {
                if (articulos[i].Activo)
                {
                    activos[index] = articulos[i];
                    index++;
                }
            }
            return activos;
        }

        public void ActualizarInventario(int idArticulo, int cantidadRestar)
        {
            for (int i = 0; i < contador; i++)
            {
                if (articulos[i].Id == idArticulo)
                {
                    articulos[i].Inventario -= cantidadRestar;
                    if (articulos[i].Inventario == 0)
                        articulos[i].Activo = false;
                    break;
                }
            }
        }

        public bool EstaLleno()
        {
            return contador >= articulos.Length;
        }
    }
}

