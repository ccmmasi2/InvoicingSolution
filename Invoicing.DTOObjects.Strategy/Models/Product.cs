namespace Invoicing.DTOObjects.Strategy.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        // Delegado para la estrategia CRUD
        public delegate void ProductoCrudEstrategia(Product producto);

        public ProductoCrudEstrategia EstrategiaCrud { get; set; }

        public void AplicarEstrategiaCrud()
        {
            EstrategiaCrud?.Invoke(this);
        }
    }
}
