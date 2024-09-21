using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NimapTest.Models;
using NimapTest.Servies;

public class ProductController : Controller
{
    private readonly DataDbContext db;

    public ProductController(DataDbContext context)
    {
        db = context;
    }

    // GET: Product (with Pagination)
    public ActionResult Index(int page = 1, int pageSize = 10)
    {
        var products = db.Products.Include(p => p.Categories)
                                  .OrderBy(p => p.ProductId)
                                  .Skip((page - 1) * pageSize)
                                  .Take(pageSize)
                                  .ToList();

        var totalRecords = db.Products.Count();
        ViewBag.TotalPages = (int)Math.Ceiling((double)totalRecords / pageSize); // Calculate and cast as int
        ViewBag.CurrentPage = page;

        return View(products);
    }


    // GET: Create Product

    // GET: Product/Create
    // GET: Product/Create
    public ActionResult Create()
    {
        LoadCatogry();
        return View(); // Ensure a new Product object is passed
    }
    [NonAction]
    private  void LoadCatogry()
    {
        var categories = db.Categories.ToList();
        ViewBag.Categories = new SelectList(categories, "CategoryId", "CategoryName");

    }
    // POST: Product/Create
    [HttpPost]
    public ActionResult Create(Product product)
    {
        db.Products.Add(product);
        db.SaveChanges();
        return RedirectToAction("Index");
    }


    // GET: Edit Product
    // GET: Product/Edit/{id}
    [HttpGet]
    public ActionResult Edit(int? id)
    {
        var product = db.Products.Find(id);
        if (product == null)
        {
            return HttpNotFound();
        }
        LoadCatogry();
      
        return View(product);
    }

    private ActionResult HttpNotFound()
    {
        throw new NotImplementedException();
    }

    [HttpPost]

    public ActionResult Edit(Product product)
    {
         db.Entry(product).State = EntityState.Modified;  // Use this for tracking changes
            db.SaveChanges();
            return RedirectToAction("Index");
      

        LoadCatogry(); // Repopulate categories when the form is invalid
        return View(product); // Return the product model to the view
    }


    // POST: Delete Product
    [HttpPost]
    public ActionResult Delete(int id)
    {
        var product = db.Products.Find(id);
        if (product != null)
        {
            db.Products.Remove(product);
            db.SaveChanges();
        }
        return RedirectToAction("Index");
    }
}
