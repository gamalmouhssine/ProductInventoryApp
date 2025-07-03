using ProductInventoryApp.Data.Repositories;
using ProductInventoryApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductInventoryApp.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public void AddProduct(Product product) => _repository.AddProduct(product);

        public List<Product> GetAllProducts() => _repository.GetAllProducts();

        public List<Product> Search(string name) => _repository.SearchProducts(name);
    }
}
