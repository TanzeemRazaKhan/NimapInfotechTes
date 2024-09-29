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

        // Get the list of all categories
        public List<Category> GetCategories()
        {
            return _context.Categories.ToList();
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

        // Delete a category by ID
        public void DeleteCategory(int id)
        {
            var category = _context.Categories.Find(id);
            if (category != null)
            {
                _context.Categories.Remove(category);
                _context.SaveChanges();
            }
        }
    }
}
