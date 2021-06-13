namespace ProyectoPuntoNet.DataAccess.Models
{
    public class SelectedCatalog
    {
        public int id_catalogo_elegido { get; set; }
        public int catalogo { get; set; }
        public int orden_de_compra { get; set; }
        public int cantidad { get; set; }
        public decimal total { get; set; }
        public string descripcion { get; set; }
        public decimal precio { get; set; }

    }
}
