namespace Capa_Entidades
{
    public class ArticuloEntidad
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public TipoArticuloEntidad TipoArticulo { get; set; }
        public double Valor { get; set; }
        public int Inventario { get; set; }
        public bool Activo { get; set; }
    }
}
