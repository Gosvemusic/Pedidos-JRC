using Capa_Entidades;
using System;

namespace Capa_Acceso_Datos
{
    public class DatosCliente
    {
        private static ClienteEntidad[] clientes = new ClienteEntidad[20];
        private static int contador = 0;

        public bool Insertar(ClienteEntidad cliente)
        {
            try
            {
                if (contador >= clientes.Length)
                    return false;

                if (ExisteIdentificacion(cliente.Identificacion))
                    return false;

                clientes[contador] = cliente;
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
                if (clientes[i].Identificacion == identificacion)
                    return true;
            }
            return false;
        }

        public ClienteEntidad[] ObtenerTodos()
        {
            ClienteEntidad[] resultado = new ClienteEntidad[contador];
            Array.Copy(clientes, resultado, contador);
            return resultado;
        }

        public ClienteEntidad[] ObtenerActivos()
        {
            int count = 0;
            for (int i = 0; i < contador; i++)
            {
                if (clientes[i].Activo)
                    count++;
            }

            ClienteEntidad[] activos = new ClienteEntidad[count];
            int index = 0;
            for (int i = 0; i < contador; i++)
            {
                if (clientes[i].Activo)
                {
                    activos[index] = clientes[i];
                    index++;
                }
            }
            return activos;
        }

        public bool EstaLleno()
        {
            return contador >= clientes.Length;
        }
    }
}


