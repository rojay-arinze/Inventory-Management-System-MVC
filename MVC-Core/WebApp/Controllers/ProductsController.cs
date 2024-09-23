using EntitiesLayer;
using Microsoft.AspNetCore.Mvc;
using UseCasesLayer.DataStorePluginInterfaces;
using UseCasesLayer.Interfaces.CategoriesUseCaseInterfaces;
using UseCasesLayer.Interfaces.ProductsUseCaseInterfaces;
using WebApp.ViewModels;
namespace WebApp.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IViewProductsUseCase _viewProductsUseCase;
        private readonly IViewSelectedProductUseCase _viewSelectedProductUseCase;
        private readonly IAddProductUseCase _addProductUseCase;
        private readonly IEditProductUseCase _editProductUseCase;
        private readonly IDeleteProductUseCase _deleteProductUseCase;
        private readonly IViewCategoriesUseCase _viewCategoriesUseCase;

        public ProductsController(IViewProductsUseCase viewProductsUseCase,
                                  IViewSelectedProductUseCase viewSelectedProductUseCase,
                                  IAddProductUseCase addProductUseCase,
                                  IEditProductUseCase editProductUseCase,
                                  IDeleteProductUseCase deleteProductUseCase,
                                  IViewCategoriesUseCase viewCategoriesUseCase)
        {
            this._viewProductsUseCase = viewProductsUseCase;
            this._viewSelectedProductUseCase = viewSelectedProductUseCase;
            this._addProductUseCase = addProductUseCase;
            this._editProductUseCase = editProductUseCase;
            this._deleteProductUseCase = deleteProductUseCase;
            this._viewCategoriesUseCase = viewCategoriesUseCase;
        }
        public IActionResult Index()
        {
            var products = _viewProductsUseCase.Execute(loadCategory:true);
            return View(products);
        }

        public IActionResult Add()
        {
            ViewBag.Action = "add";
            ProductViewModel productsViewModel = new ProductViewModel()
            {
                Categories = _viewCategoriesUseCase.Execute() //populate the list of categories with categories

            };//initialize a viewmodel to be passed to the add view
            return View(productsViewModel); //bind the viewmodel with the view and render the view
        }

        [HttpPost]
        public IActionResult Add(ProductViewModel productViewModel) //handle the result
        {
            if(ModelState.IsValid)
            {
                var product = productViewModel.Product; 
                _addProductUseCase.Execute(product);
                return RedirectToAction(nameof(Index));
            }
            productViewModel.Categories = _viewCategoriesUseCase.Execute();
            return View(productViewModel); //if it fails, take them back to the same page with error messages

        }

        public IActionResult Edit(int id)
        {
            ViewBag.Action = "edit";
            var productVM = new ProductViewModel()
            {

                Categories = _viewCategoriesUseCase.Execute(),
                Product = _viewSelectedProductUseCase.Execute(id) ?? new Product()
            };
            
            return View(productVM);
        }
        [HttpPost]
        public IActionResult Edit( ProductViewModel productVM)
        {
            if (ModelState.IsValid)
            {
                var productToUpdate = productVM.Product;
                _editProductUseCase.Execute(productToUpdate.ProductId, productToUpdate);
                return RedirectToAction(nameof(Index));
            }
            productVM.Categories = _viewCategoriesUseCase.Execute();
            return View(productVM);
        }

        public  IActionResult  Delete (int id)
        {
            _deleteProductUseCase.Execute(id);
            return RedirectToAction(nameof(Index));
        }


    }
}
