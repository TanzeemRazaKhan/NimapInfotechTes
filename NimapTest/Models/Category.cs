using Microsoft.EntityFrameworkCore;
using NimapTest.Servies;
using System.ComponentModel.DataAnnotations;

namespace NimapTest.Models
{
    public class Category
    {

        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Category name is required.")]
        public string CategoryName { get; set; } = "";

        public Category() { }


    }

    //public class Category : ICategoryService
    //{
    //    private readonly DataDbContext _context;

    //    public Category(DataDbContext context)
    //    {
    //        _context = context;
    //    }

    //    public List<Category> GetCategories()
    //    {
    //        return _context.Categories.ToList();
    //    }

    //    public Category GetCategoryById(int id)
    //    {
    //        return _context.Categories.Find(id);
    //    }

    //    public void AddCategory(Category category)
    //    {
    //        _context.Categories.Add(category);
    //        _context.SaveChanges();
    //    }

    //    public void UpdateCategory(Category category)
    //    {
    //        _context.Entry(category).State = EntityState.Modified;
    //        _context.SaveChanges();
    //    }

    //    public void DeleteCategory(int id)
    //    {
    //        var category = _context.Categories.Find(id);
    //        if (category != null)
    //        {
    //            _context.Categories.Remove(category);
    //            _context.SaveChanges();
    //        }
    //    }

    //}

}
