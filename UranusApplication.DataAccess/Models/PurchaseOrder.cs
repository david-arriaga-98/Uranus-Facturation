using System;

namespace ProyectoPuntoNet.DataAccess.Models
{
    public class PurchaseOrder
    {
        public int id_orden_de_compra { get; set; }
        public int cliente { get; set; }
        public int vendedor { get; set; }
        public bool estado { get; set; }
        public decimal subtotal { get; set; }
        public decimal descuento { get; set; }
        public decimal impuestos { get; set; }
        public decimal total { get; set; }
        public string codigo { get; set; }
        public DateTime fecha_generada { get; set; }
        public DateTime fecha_cerrada { get; set; }

    }
}
