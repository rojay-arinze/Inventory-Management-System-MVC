using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    public class SalesController : Controller
    {
        public IActionResult Index()
        {
            var sales = new SalesViewModel()
            {
                Categories = CategoriesRepository.GetCategories()
            };
            return View(sales);
        }

        public IActionResult SalesPartial(int productId)
        {
            
                var product = ProductsRepository.GetProductById(productId);
                return PartialView("_Sales", product);
        }
    }
}
