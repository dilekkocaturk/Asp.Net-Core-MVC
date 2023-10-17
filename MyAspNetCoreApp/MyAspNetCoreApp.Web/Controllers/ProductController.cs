using Microsoft.AspNetCore.Mvc;
using MyAspNetCoreApp.Web.Models;

namespace MyAspNetCoreApp.Web.Controllers
{
    public class ProductController : Controller
    {
        private AppDbContext _context;

        private readonly ProductRepository _productRepository;

        public ProductController(AppDbContext context)
        {
            _productRepository = new ProductRepository();

            _context = context;

            //if (!_context.Products.Any())
            //{
            //    _context.Products.Add(new Product { Name = "Kalem 1", Price = 100, Stock = 100, Color = "Red" });
            //    _context.Products.Add(new Product { Name = "Kalem 2", Price = 100, Stock = 200, Color = "Red" });
            //    _context.Products.Add(new Product { Name = "Kalem 3", Price = 100, Stock = 300, Color = "Red" });

            //    _context.SaveChanges();
            //}

        }
        public IActionResult Index()
        {
            var products= _context.Products.ToList();

            return View(products);
        }

        public IActionResult Remove(int id)
        {
            var product = _context.Products.Find(id);

            _context.Products.Remove(product);

            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Product newProduct)
        {
            // Request Header-Body

            //1. yöntem
            //var name = HttpContext.Request.Form["Name"].ToString();
            //var price = decimal.Parse(HttpContext.Request.Form["Price"].ToString());
            //var stock = int.Parse(HttpContext.Request.Form["Stock"].ToString());
            //var color = HttpContext.Request.Form["Color"].ToString();

            //2. yöntem
            //Product newProduct = new Product() { Name = Name, Price = Price, Color = Color, Stock = Stock };

            _context.Products.Add(newProduct);
            _context.SaveChanges();

            TempData["status"] = "Ürün başarıyla eklendi.";
            return RedirectToAction("Index");


        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var product= _context.Products.Find(id);
            return View(product);
        }

        [HttpPost]
        public IActionResult Update(Product updateProduct, int productId)
        {
            updateProduct.Id= productId;
            _context.Products.Update(updateProduct);
            _context.SaveChanges();

            TempData["status"] = "Ürün başarıyla güncellendi.";
            return RedirectToAction("Index");
        }
    }
}
