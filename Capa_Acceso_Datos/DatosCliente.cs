//* [UNED Perez Zeledon]//
//* II Cuatrimestre 2025//
//* Sistema de Gestion de Pedidos//
//* [Javier Rojas Cordero]//
//* Fecha: 27/05/2025//


using Capa_Entidades;
using System;

namespace Capa_Acceso_Datos
{
    public class DatosCliente // Define la clase DatosCliente
    {
        private static ClienteEntidad[] clientes = new ClienteEntidad[20]; // Arreglo estatico para almacenar clientes
        private static int contador = 0; // Contador de clientes almacenados

        public bool Insertar(ClienteEntidad cliente) // Metodo para insertar un cliente
        {
            try // Inicia el bloque try
            {
                if (contador >= clientes.Length) // Verifica si el arreglo esta lleno
                    return false; // Retorna falso si esta lleno

                if (ExisteIdentificacion(cliente.Identificacion)) // Verifica si la identificacion ya existe
                    return false; // Retorna falso si la identificacion ya existe

                clientes[contador] = cliente; // Asigna el cliente en la posicion actual
                contador++; // Incrementa el contador
                return true; // Retorna verdadero si se inserto correctamente
            }
            catch (Exception) // Captura cualquier excepcion
            {
                throw; // Relanza la excepcion
            }
        }

        public bool ExisteIdentificacion(int identificacion) // Metodo para verificar si existe una identificacion
        {
            for (int i = 0; i < contador; i++) // Recorre los clientes almacenados
            {
                if (clientes[i].Identificacion == identificacion) // Compara la identificacion
                    return true; // Retorna verdadero si encuentra la identificacion
            }
            return false; // Retorna falso si no encuentra la identificacion
        }

        public ClienteEntidad[] ObtenerTodos() // Metodo para obtener todos los clientes
        {
            ClienteEntidad[] resultado = new ClienteEntidad[contador]; // Crea un nuevo arreglo del tamano actual
            Array.Copy(clientes, resultado, contador); // Copia los clientes al nuevo arreglo
            return resultado; // Retorna el arreglo de clientes
        }

        public ClienteEntidad[] ObtenerActivos() // Metodo para obtener solo los clientes activos
        {
            int count = 0; // Inicializa el contador de activos
            for (int i = 0; i < contador; i++) // Recorre los clientes almacenados
            {
                if (clientes[i].Activo) // Verifica si el cliente esta activo
                    count++; // Incrementa el contador de activos
            }

            ClienteEntidad[] activos = new ClienteEntidad[count]; // Crea un arreglo para los activos
            int index = 0; // Inicializa el indice para el arreglo de activos
            for (int i = 0; i < contador; i++) // Recorre los clientes almacenados
            {
                if (clientes[i].Activo) // Verifica si el cliente esta activo
                {
                    activos[index] = clientes[i]; // Asigna el cliente activo al arreglo
                    index++; // Incrementa el indice
                }
            }
            return activos; // Retorna el arreglo de clientes activos
        }

        public bool EstaLleno() // Metodo para verificar si el arreglo esta lleno
        {
            return contador >= clientes.Length; // Retorna verdadero si el contador es mayor o igual al tamano del arreglo
        }
    }
}


