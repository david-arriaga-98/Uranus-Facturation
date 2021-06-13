namespace ProyectoPuntoNet.DataAccess.Models
{
    public class Catalog
    {
        public int id_catalogo { get; set; }
        public string nombre { get; set; }
        public decimal precio { get; set; }
        public int cantidad { get; set; }
        public string descripcion { get; set; }
        public string imagen_id { get; set; }
    }
}
