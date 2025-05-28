using Capa_Entidades;
using System;

namespace Capa_Acceso_Datos
{
    public class DatosRepartidor
    {
        private static RepartidorEntidad[] repartidores = new RepartidorEntidad[20];
        private static int contador = 0;

        public bool Insertar(RepartidorEntidad repartidor)
        {
            try
            {
                if (contador >= repartidores.Length)
                    return false;

                if (ExisteIdentificacion(repartidor.Identificacion))
                    return false;

                repartidores[contador] = repartidor;
                contador++;
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool ExisteIdentificacion(int identificacion)
        {
            for (int i = 0; i < contador; i++)
            {
                if (repartidores[i].Identificacion == identificacion)
                    return true;
            }
            return false;
        }

        public RepartidorEntidad[] ObtenerTodos()
        {
            RepartidorEntidad[] resultado = new RepartidorEntidad[contador];
            Array.Copy(repartidores, resultado, contador);
            return resultado;
        }

        public RepartidorEntidad[] ObtenerActivos()
        {
            int count = 0;
            for (int i = 0; i < contador; i++)
            {
                if (repartidores[i].Activo)
                    count++;
            }

            RepartidorEntidad[] activos = new RepartidorEntidad[count];
            int index = 0;
            for (int i = 0; i < contador; i++)
            {
                if (repartidores[i].Activo)
                {
                    activos[index] = repartidores[i];
                    index++;
                }
            }
            return activos;
        }

        public bool EstaLleno()
        {
            return contador >= repartidores.Length;
        }
    }
}
