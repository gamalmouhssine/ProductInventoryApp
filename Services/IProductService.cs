using ProductInventoryApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductInventoryApp.Services
{
    public interface IProductService
    {
        void AddProduct(Product product);
        List<Product> GetAllProducts();
        List<Product> Search(string name);
    }
}
