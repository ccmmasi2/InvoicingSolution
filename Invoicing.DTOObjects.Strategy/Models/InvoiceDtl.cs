namespace Invoicing.DTOObjects.Strategy.Models
{
    public class InvoiceDtl
    {
        public int ID { get; set; }
        public string InvoiceNum { get; set; }
        public int Order { get; set; }
        public int IDProduct { get; set; }
        public double Price { get; set; }
        public int QTY { get; set; }

        // Delegado para la estrategia CRUD
        public delegate void CategoriaCrudEstrategia(InvoiceDtl categoria);

        public CategoriaCrudEstrategia EstrategiaCrud { get; set; }

        public void AplicarEstrategiaCrud()
        {
            EstrategiaCrud?.Invoke(this);
        }
    }
}
