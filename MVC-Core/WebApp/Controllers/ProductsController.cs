using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using WebApp.ViewModels;
namespace WebApp.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            var products = ProductsRepository.GetProducts(loadCategory:true);
            return View(products);
        }

        public IActionResult Add()
        {
            ProductViewModel productsViewModel = new ProductViewModel(); //initialize a viewmodel to be passed to the add view
            productsViewModel.Categories = CategoriesRepository.GetCategories(); //populate the list of categories with categories
            return View(productsViewModel); //bind the viewmodel with the view and render the view
        }

        [HttpPost]
        public IActionResult Add(ProductViewModel productViewModel) //handle the result
        {
            if(ModelState.IsValid)
            {
                var product = productViewModel.Product; 
                ProductsRepository.AddProduct(product);
                return RedirectToAction(nameof(Index));
            }
            productViewModel.Categories = CategoriesRepository.GetCategories();
            return View(productViewModel); //if it fails, take them back to the same page with error messages

        }

        public IActionResult Edit(ProductViewModel productVM)
        {

            productVM.Categories = CategoriesRepository.GetCategories();
            return View(productVM);
        }

    }
}
