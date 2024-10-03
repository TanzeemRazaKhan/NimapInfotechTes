using Microsoft.EntityFrameworkCore;
using NimapTest.Models;
using NimapTest.Servies;
using System.Collections.Generic;
using System.Linq;

namespace NimapTest.Services
{
    public class ProductService : IProductService
    {
        private readonly DataDbContext _context;

        public ProductService(DataDbContext context)
        {
            _context = context;
        }

        public List<Product> GetProducts(int page, int pageSize)
        {
            return _context.Products.Include(p => p.Categories)
                                    .OrderBy(p => p.ProductId)
                                    .Skip((page - 1) * pageSize) 
                                    .Take(pageSize)             
                                    .ToList();
        }

        public int GetTotalProductCount()
        {
            return _context.Products.Count();
        }
        public Product GetProductById(int id)
        {
            return _context.Products.Include(p => p.Categories).FirstOrDefault(p => p.ProductId == id);
        }

        public void AddProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void UpdateProduct(Product product)
        {
            _context.Entry(product).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteProduct(int id)
        {
            var product = _context.Products.Find(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
        }

        //public int GetTotalProductCount()
        //{
        //    return _context.Products.Count();
        //}
    }
}
