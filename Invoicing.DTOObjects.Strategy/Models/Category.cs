namespace Invoicing.DTOObjects.Strategy.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Delegado para la estrategia CRUD
        public delegate void CategoriaCrudEstrategia(Category categoria);

        public CategoriaCrudEstrategia EstrategiaCrud { get; set; }

        public void AplicarEstrategiaCrud()
        {
            EstrategiaCrud?.Invoke(this);
        }
    }
}
