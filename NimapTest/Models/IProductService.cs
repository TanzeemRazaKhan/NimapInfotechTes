using NimapTest.Models;
using System.Collections.Generic;

namespace NimapTest.Services
{
    public interface IProductService
    {
        List<Product> GetProducts(int page, int pageSize);
        Product GetProductById(int id);
        void AddProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(int id);
        int GetTotalProductCount();
    }
}
