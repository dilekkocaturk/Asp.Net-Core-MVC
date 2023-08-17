using Microsoft.AspNetCore.Mvc;

namespace MyAspNetCoreApp.Web.Controllers
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class OrnekController : Controller
    {
        public IActionResult Index()
        {
            var ProductList = new List<Product>()
            {
                new(){Id=1, Name="kalem" },
                new(){Id=2, Name="Defter" },
                new(){Id=3,Name="Silgi" }
            };

            return View(ProductList);
        }

        public IActionResult Index2()
        {
            var surName = TempData["surname"];
            return View();
        }


        public IActionResult Index3()
        {
            //veritabanı kaydetme işlemi

            return RedirectToAction("Index", "Ornek");
        }

        public IActionResult ContentResult()
        {
            return Content("ContentResult");
        }

        public IActionResult JsonResult()
        {
            return Json(new { Id = 1, name = "kalem", price = 100 });
        }

        public IActionResult EmptyResult()
        {
            return new EmptyResult();
        }
    }
}
