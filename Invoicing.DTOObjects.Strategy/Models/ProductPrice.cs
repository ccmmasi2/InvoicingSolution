namespace Invoicing.DTOObjects.Strategy.Models
{
    public class ProductPrice
    {
        public int ID { get; set; }
        public int IDProduct { get; set; }
        public double? Price { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        // Delegado para la estrategia CRUD
        public delegate void CategoriaCrudEstrategia(ProductPrice categoria);

        public CategoriaCrudEstrategia EstrategiaCrud { get; set; }

        public void AplicarEstrategiaCrud()
        {
            EstrategiaCrud?.Invoke(this);
        }
    }
}
