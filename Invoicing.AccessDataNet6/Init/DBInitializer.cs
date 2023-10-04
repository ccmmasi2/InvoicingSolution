using Invoicing.AccessDataNet6.Data;
using Invoicing.DTOObjectsNet6.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace Invoicing.AccessDataNet6.Init
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

            if (!_db.Category.Any())
            {
                var categoriesData = File.ReadAllText("../Invoicing.AccessData/Data/SeedData/Category.json");
                var categories = JsonSerializer.Deserialize<List<Category>>(categoriesData);
                _db.Category.AddRange(categories);
            }

            if (!_db.Store.Any())
            {
                var storesData = File.ReadAllText("../Invoicing.AccessData/Data/SeedData/Store.json");
                var stores = JsonSerializer.Deserialize<List<Store>>(storesData);
                _db.Store.AddRange(stores);
            }

            if (!_db.Client.Any())
            {
                var clientsData = File.ReadAllText("../Invoicing.AccessData/Data/SeedData/Client.json");
                var clients = JsonSerializer.Deserialize<List<Client>>(clientsData);
                _db.Client.AddRange(clients);
            }

            if (!_db.Product.Any())
            {
                var productsData = File.ReadAllText("../Invoicing.AccessData/Data/SeedData/Product.json");
                var products = JsonSerializer.Deserialize<List<Product>>(productsData);
                _db.Product.AddRange(products);
            }

            if (!_db.ProductPrice.Any())
            {
                var productPricesData = File.ReadAllText("../Invoicing.AccessData/Data/SeedData/ProductPrice.json");
                var productPrices = JsonSerializer.Deserialize<List<ProductPrice>>(productPricesData);
                _db.ProductPrice.AddRange(productPrices);
            }

            if (_db.ChangeTracker.HasChanges())
                _db.SaveChanges();
        }
    }
}
