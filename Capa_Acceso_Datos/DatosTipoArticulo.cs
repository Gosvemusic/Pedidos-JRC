using Capa_Entidades;
using System;

namespace Capa_Acceso_Datos
{
    public class DatosTipoArticulo
    {
        private static TipoArticuloEntidad[] tiposArticulo = new TipoArticuloEntidad[10];
        private static int contador = 0;

        public bool Insertar(TipoArticuloEntidad tipo)
        {
            try
            {
                if (contador >= tiposArticulo.Length)
                    return false;

                if (ExisteId(tipo.Id))
                    return false;

                tiposArticulo[contador] = tipo;
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
                if (tiposArticulo[i].Id == id)
                    return true;
            }
            return false;
        }

        public TipoArticuloEntidad[] ObtenerTodos()
        {
            TipoArticuloEntidad[] resultado = new TipoArticuloEntidad[contador];
            Array.Copy(tiposArticulo, resultado, contador);
            return resultado;
        }

        public bool EstaLleno()
        {
            return contador >= tiposArticulo.Length;
        }
    }
}


