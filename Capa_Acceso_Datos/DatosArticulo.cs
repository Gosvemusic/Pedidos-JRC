//* [UNED Perez Zeledon]//
//* II Cuatrimestre 2025//
//* Sistema de Gestion de Pedidos//
//* [Javier Rojas Cordero]//
//* Fecha: 27/05/2025//



using Capa_Entidades;
using System;

namespace Capa_Acceso_Datos
{
    public class DatosArticulo // Define la clase DatosArticulo
    {
        private static ArticuloEntidad[] articulos = new ArticuloEntidad[20]; // Arreglo estatico para almacenar articulos
        private static int contador = 0; // Contador de articulos almacenados

        public bool Insertar(ArticuloEntidad articulo) // Metodo para insertar un articulo
        {
            try // Inicia el bloque try
            {
                if (contador >= articulos.Length) // Verifica si el arreglo esta lleno
                    return false; // Retorna falso si esta lleno

                if (ExisteId(articulo.Id)) // Verifica si el ID ya existe
                    return false; // Retorna falso si el ID ya existe

                articulos[contador] = articulo; // Asigna el articulo en la posicion actual
                contador++; // Incrementa el contador
                return true; // Retorna verdadero si se inserto correctamente
            }
            catch (Exception) // Captura cualquier excepcion
            {
                throw; // Relanza la excepcion
            }
        }

        public bool ExisteId(int id) // Metodo para verificar si existe un ID
        {
            for (int i = 0; i < contador; i++) // Recorre los articulos almacenados
            {
                if (articulos[i].Id == id) // Compara el ID
                    return true; // Retorna verdadero si encuentra el ID
            }
            return false; // Retorna falso si no encuentra el ID
        }

        public ArticuloEntidad[] ObtenerTodos() // Metodo para obtener todos los articulos
        {
            ArticuloEntidad[] resultado = new ArticuloEntidad[contador]; // Crea un nuevo arreglo del tamano actual
            Array.Copy(articulos, resultado, contador); // Copia los articulos al nuevo arreglo
            return resultado; // Retorna el arreglo de articulos
        }

        public ArticuloEntidad[] ObtenerActivos() // Metodo para obtener solo los articulos activos
        {
            int count = 0; // Inicializa el contador de activos
            for (int i = 0; i < contador; i++) // Recorre los articulos almacenados
            {
                if (articulos[i].Activo) // Verifica si el articulo esta activo
                    count++; // Incrementa el contador de activos
            }

            ArticuloEntidad[] activos = new ArticuloEntidad[count]; // Crea un arreglo para los activos
            int index = 0; // Inicializa el indice para el arreglo de activos
            for (int i = 0; i < contador; i++) // Recorre los articulos almacenados
            {
                if (articulos[i].Activo) // Verifica si el articulo esta activo
                {
                    activos[index] = articulos[i]; // Asigna el articulo activo al arreglo
                    index++; // Incrementa el indice
                }
            }
            return activos; // Retorna el arreglo de articulos activos
        }

        public void ActualizarInventario(int idArticulo, int cantidadRestar) // Metodo para actualizar el inventario de un articulo
        {
            for (int i = 0; i < contador; i++) // Recorre los articulos almacenados
            {
                if (articulos[i].Id == idArticulo) // Busca el articulo por ID
                {
                    articulos[i].Inventario -= cantidadRestar; // Resta la cantidad al inventario
                    if (articulos[i].Inventario == 0) // Si el inventario llega a cero
                        articulos[i].Activo = false; // Marca el articulo como inactivo
                    break; // Sale del ciclo
                }
            }
        }

        public bool EstaLleno() // Metodo para verificar si el arreglo esta lleno
        {
            return contador >= articulos.Length; // Retorna verdadero si el contador es mayor o igual al tamano del arreglo
        }
    }
}

