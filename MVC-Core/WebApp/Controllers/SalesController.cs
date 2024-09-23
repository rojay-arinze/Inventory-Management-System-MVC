using Microsoft.AspNetCore.Mvc;
using UseCasesLayer.Interfaces.CategoriesUseCaseInterfaces;
using UseCasesLayer.Interfaces.ProductsUseCaseInterfaces;
using UseCasesLayer.ProductsUseCases;
using WebApp.Models;
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    public class SalesController : Controller
    {
        private readonly IViewCategoriesUseCase viewCategoriesUseCase;
        private readonly IViewSelectedProductUseCase viewSelectedProductUseCase;
        private readonly ISellProductUseCase sellProductUseCase;
        private readonly IViewProductsByCategoryIdUseCase viewProductsByCategoryIdUseCase;

        public SalesController(IViewCategoriesUseCase viewCategoriesUseCase,
                               IViewSelectedProductUseCase viewSelectedProductUseCase,
                               ISellProductUseCase sellProductUseCase,
                               IViewProductsByCategoryIdUseCase viewProductsByCategoryIdUseCase)
        {
            this.viewCategoriesUseCase = viewCategoriesUseCase;
            this.viewSelectedProductUseCase = viewSelectedProductUseCase;
            this.sellProductUseCase = sellProductUseCase;
            this.viewProductsByCategoryIdUseCase = viewProductsByCategoryIdUseCase;
        }
        public IActionResult Index()
        {
            var sales = new SalesViewModel
            {
                Categories = viewCategoriesUseCase.Execute()
            };
            return View(sales);
        }

        public IActionResult SalesPartial(int productId)
        {
            
                var product = viewSelectedProductUseCase.Execute(productId);
                return PartialView("_Sales", product);
        }

        public IActionResult Sell(SalesViewModel salesViewModel)
        {
            if(ModelState.IsValid)
            {
                //sell product
                //var prod = ProductsRepository.GetProductById(salesViewModel.SelectedProductId);
                //if (prod != null) 
                //{
                //    TransactionsRepository.Add(
                //        "Cashier1",
                //        salesViewModel.SelectedProductId,
                //        prod.Name,
                //        prod.Price.HasValue?prod.Price.Value : 0,
                //        prod.Quantity.HasValue?prod.Quantity.Value: 0,
                //        salesViewModel.QuantityToSell
                //        );
                //    prod.Quantity -= salesViewModel.QuantityToSell;
                //    ProductsRepository.UpdateProduct(salesViewModel.SelectedProductId, prod);
                //}
                sellProductUseCase.Execute(
                    "Cashier1",
                     salesViewModel.SelectedProductId,
                     salesViewModel.QuantityToSell);
            }
            var product = viewSelectedProductUseCase.Execute(salesViewModel.SelectedProductId);
            salesViewModel.SelectedCategoryId = (product?.CategoryId == null)? 0:product.CategoryId.Value;
            salesViewModel.Categories = viewCategoriesUseCase.Execute();
            return View("Index", salesViewModel);
        }
        public IActionResult ProductsByCategoryPartial(int categoryId) //create an action to handle the products partial view
        {
            var products = viewProductsByCategoryIdUseCase.Execute(categoryId);

            return PartialView("_Products", products);
        }
    }
}
