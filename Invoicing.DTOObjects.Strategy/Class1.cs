using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoicing.DTOObjects.Strategy
{
    public interface ICrudStrategy<T>
    {
        void Crear(T objeto);
        void Leer(T objeto);
        void Actualizar(T objeto);
        void Eliminar(T objeto);
    }
    public class CrudCategoria : ICrudStrategy<Category>
    {
        public void Crear(Category categoria)
        {
            // Implementa la lógica para crear una categoría en la base de datos.
        }

        public void Leer(Category categoria)
        {
            // Implementa la lógica para leer información de una categoría de la base de datos.
        }

        public void Actualizar(Category categoria)
        {
            // Implementa la lógica para actualizar una categoría en la base de datos.
        }

        public void Eliminar(Category categoria)
        {
            // Implementa la lógica para eliminar una categoría de la base de datos.
        }
    }

    public class CrudProducto : ICrudStrategy<Product>
    {
        public void Crear(Product producto)
        {
            // Implementa la lógica para crear un producto en la base de datos.
        }

        public void Leer(Product producto)
        {
            // Implementa la lógica para leer información de un producto de la base de datos.
        }

        public void Actualizar(Product producto)
        {
            // Implementa la lógica para actualizar un producto en la base de datos.
        }

        public void Eliminar(Product producto)
        {
            // Implementa la lógica para eliminar un producto de la base de datos.
        }
    }
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

    public class ClassTest
    {
        public void testeo()
        {
            var categoria = new Category { Id = 1, Name = "Electrónicos" };
            var producto = new Product { Id = 101, Name = "Teléfono", Price = 499.99M };

            // Asignar estrategias CRUD a los objetos
            categoria.EstrategiaCrud = new CrudCategoria().Crear;
            producto.EstrategiaCrud = new CrudProducto().Crear;

            // Aplicar estrategias CRUD
            categoria.AplicarEstrategiaCrud(); // Realizará la operación de creación para la categoría
            producto.AplicarEstrategiaCrud();
        }
    }
}
