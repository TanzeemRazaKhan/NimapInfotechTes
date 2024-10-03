using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using NimapTest.Models;
using NimapTest.Services;

public class ProductController : Controller
{
    private readonly IProductService _productService;
    private readonly ICategoryService _categoryService;

    public ProductController(IProductService productService, ICategoryService categoryService)
    {
        _productService = productService;
        _categoryService = categoryService;
    }

    // GET: Product (with Pagination)
    //public ActionResult Index(int page = 1, int pageSize = 10)
    //{
    //    var products = _productService.GetProducts(page, pageSize);
    //    var totalRecords = _productService.GetTotalProductCount();

    //    ViewBag.TotalPages = (int)Math.Ceiling((double)totalRecords / pageSize);
    //    ViewBag.CurrentPage = page;

    //    return View(products);
    //}
   public ActionResult Index(int page = 1, int pageSize = 10)
{
    var products = _productService.GetProducts(page, pageSize); // Fetch paginated products
    var totalRecords = _productService.GetTotalProductCount();  // Get total product count

    ViewBag.TotalPages = (int) Math.Ceiling((double) totalRecords / pageSize); // Calculate total pages
    ViewBag.CurrentPage = page;

    return View(products);
}


public ActionResult Create()
    {
        LoadCategories();
        return View();
    }

    [HttpPost]
    public ActionResult Create(Product product)
    {
        
            _productService.AddProduct(product);
            return RedirectToAction("Index");
       
        LoadCategories();
        return View(product);
    }

    public ActionResult Edit(int id)
    {
        var product = _productService.GetProductById(id);
        if (product == null)
        {
            return NotFound();
        }
        LoadCategories();
        return View(product);
    }

    [HttpPost]
    public ActionResult Edit(Product product)
    {
       
            _productService.UpdateProduct(product);
            return RedirectToAction("Index");
     
        LoadCategories();
        return View(product);
    }

    [HttpPost]
    public ActionResult Delete(int id)
    {
        _productService.DeleteProduct(id);
        return RedirectToAction("Index");
    }

    private void LoadCategories()
    {
        var categories = _categoryService.GetCategories(1, int.MaxValue);
        ViewBag.Categories = new SelectList(categories, "CategoryId", "CategoryName");
    }
}
