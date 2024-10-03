using Microsoft.AspNetCore.Mvc;
using NimapTest.Models;
using NimapTest.Services;

namespace NimapTest.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET: Category
        public ActionResult Index(int page = 1, int pageSize = 10) 
        {
            var categories = _categoryService.GetCategories(page, pageSize);
            var totalRecords = _categoryService.GetTotalCategoryCount();

            ViewBag.TotalPages = (int)Math.Ceiling((double)totalRecords / pageSize);
            ViewBag.CurrentPage = page;

            return View(categories);
        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                _categoryService.AddCategory(category);
                return RedirectToAction("Index");
            }
            return View(category);
        }

        public ActionResult Edit(int id)
        {
            var category = _categoryService.GetCategoryById(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost]
        public ActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                _categoryService.UpdateCategory(category);
                return RedirectToAction("Index");
            }
            return View(category);
        }

        [HttpPost]
       
        public ActionResult Delete(int id)
        {
            try
            {
                _categoryService.DeleteCategory(id); 
                return RedirectToAction("Index");
            }
            catch (InvalidOperationException ex) 
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("Index"); 
            }
            catch (Exception ex) 
            {
                TempData["ErrorMessage"] = "An error occurred while trying to delete the category.";
                return RedirectToAction("Index");
            }
        }

    }
}
