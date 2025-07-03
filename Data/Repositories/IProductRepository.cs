using ProductInventoryApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductInventoryApp.Data.Repositories
{
    public interface IProductRepository
    {
        void AddProduct(Product product);
        List<Product> GetAllProducts();
        List<Product> SearchProducts(string name);
    }
}
