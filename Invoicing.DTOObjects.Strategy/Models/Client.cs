namespace Invoicing.DTOObjects.Strategy.Models
{
    public class Client
    {
        public int ID { get; set; }
        public string Identification { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDay { get; set; }
        public string PhoneNumber { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }

        // Delegado para la estrategia CRUD
        public delegate void CategoriaCrudEstrategia(Client categoria);

        public CategoriaCrudEstrategia EstrategiaCrud { get; set; }

        public void AplicarEstrategiaCrud()
        {
            EstrategiaCrud?.Invoke(this);
        }
    }
}
