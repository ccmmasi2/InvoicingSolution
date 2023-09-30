using Invoicing.AccessData.Data;
using Invoicing.DTOObjects.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace Invoicing.AccessData.Init
{
    public class DBInitializer : IDBInitializer
    {
        private readonly AppDbContext _db;

        public DBInitializer(AppDbContext db)
        {
            _db = db;
        }

        public void Initialize()
        {
            try
            {
                if (_db.Database.GetPendingMigrations().Count() > 0)
                {
                    _db.Database.Migrate();
                }
            }
            catch (Exception)
            {
                throw;
            }

            if (!_db.Categories.Any())
            {
                var categoriesData = File.ReadAllText("../Invoicing.AccessData/Data/SeedData/Categories.json");
                var categories = JsonSerializer.Deserialize<List<CategoryDTO>>(categoriesData);
                _db.Categories.AddRange(categories);
            }

            if (!_db.Stores.Any())
            {
                var storesData = File.ReadAllText("../Invoicing.AccessData/Data/SeedData/Stores.json");
                var stores = JsonSerializer.Deserialize<List<StoreDTO>>(storesData);
                _db.Stores.AddRange(stores);
            }

            if (!_db.Clients.Any())
            {
                var clientsData = File.ReadAllText("../Invoicing.AccessData/Data/SeedData/Clients.json");
                var clients = JsonSerializer.Deserialize<List<ClientDTO>>(clientsData);
                _db.Clients.AddRange(clients);
            }

            if (!_db.Products.Any())
            {
                var productsData = File.ReadAllText("../Invoicing.AccessData/Data/SeedData/Products.json");
                var products = JsonSerializer.Deserialize<List<ProductDTO>>(productsData);
                _db.Products.AddRange(products);
            }

            if (!_db.ProductPrices.Any())
            {
                var productPricesData = File.ReadAllText("../Invoicing.AccessData/Data/SeedData/ProductPrices.json");
                var productPrices = JsonSerializer.Deserialize<List<ProductPriceDTO>>(productPricesData);
                _db.ProductPrices.AddRange(productPrices);
            }

            if (_db.ChangeTracker.HasChanges())
                _db.SaveChanges();
        }
    }
}
