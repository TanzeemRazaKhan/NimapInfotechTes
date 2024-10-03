using Microsoft.EntityFrameworkCore;
using NimapTest.Models;
using NimapTest.Servies;
using System.Collections.Generic;
using System.Linq;

namespace NimapTest.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly DataDbContext _context;

        // Injecting the database context
        public CategoryService(DataDbContext context)
        {
            _context = context;
        }

        // Get a paginated list of categories
        public List<Category> GetCategories(int page, int pageSize)
        {
            return _context.Categories
                .OrderBy(c => c.CategoryId) // Sort categories by ID
                .Skip((page - 1) * pageSize) // Skip records based on the current page
                .Take(pageSize) // Take only the records for the current page
                .ToList();
        }
        // Get total count of categories for pagination
        public int GetTotalCategoryCount()
        {
            return _context.Categories.Count();
        }

    

        // Get a single category by ID
        public Category GetCategoryById(int id)
        {
            return _context.Categories.Find(id);
        }

        // Add a new category
        public void AddCategory(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
        }

        // Update an existing category
        public void UpdateCategory(Category category)
        {
            _context.Entry(category).State = EntityState.Modified;
            _context.SaveChanges();
        }

 

        public void DeleteCategory(int id)
        {
            var category = _context.Categories.Find(id);

            // Check if any products are associated with this category
            if (category != null)
            {
                bool hasProducts = _context.Products.Any(p => p.CategoryId == id);
                if (hasProducts)
                {
                    // Optionally, you can log the attempt here
                    throw new InvalidOperationException("Cannot delete this category because products are associated with it.");
                }

                _context.Categories.Remove(category);
                _context.SaveChanges();
            }
        }

    }
}
