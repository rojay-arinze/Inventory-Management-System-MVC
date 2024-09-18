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
            ViewBag.Action = "add";
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

        public IActionResult Edit(int id)
        {
            ViewBag.Action = "edit";
            var productVM = new ProductViewModel()
            {

                Categories = CategoriesRepository.GetCategories(),
                Product = ProductsRepository.GetProductById(id) ?? new Product()
            };
            
            return View(productVM);
        }
        [HttpPost]
        public IActionResult Edit( ProductViewModel productVM)
        {
            if (ModelState.IsValid)
            {
                var productToUpdate = productVM.Product;
                ProductsRepository.UpdateProduct(productToUpdate.ProductId, productToUpdate);
                return RedirectToAction(nameof(Index));
            }
            productVM.Categories = CategoriesRepository.GetCategories();
            return View(productVM);
        }

    }
}
