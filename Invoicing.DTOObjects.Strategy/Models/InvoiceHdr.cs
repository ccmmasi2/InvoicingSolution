namespace Invoicing.DTOObjects.Strategy.Models
{
    public class InvoiceHdr
    {
        public string InvoiceNum { get; set; }
        public DateTime Date { get; set; }
        public int IDClient { get; set; }
        public int IDStore { get; set; }

        // Delegado para la estrategia CRUD
        public delegate void CategoriaCrudEstrategia(InvoiceHdr categoria);

        public CategoriaCrudEstrategia EstrategiaCrud { get; set; }

        public void AplicarEstrategiaCrud()
        {
            EstrategiaCrud?.Invoke(this);
        }
    }
}
