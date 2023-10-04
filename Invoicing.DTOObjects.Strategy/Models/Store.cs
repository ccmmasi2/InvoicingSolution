namespace Invoicing.DTOObjects.Strategy.Models
{
    public class Store
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Address { get; set; }

        // Delegado para la estrategia CRUD
        public delegate void CategoriaCrudEstrategia(Store categoria);

        public CategoriaCrudEstrategia EstrategiaCrud { get; set; }

        public void AplicarEstrategiaCrud()
        {
            EstrategiaCrud?.Invoke(this);
        }
    }
}
