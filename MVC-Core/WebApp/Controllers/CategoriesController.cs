using EntitiesLayer;
using Microsoft.AspNetCore.Mvc;
using UseCasesLayer.Interfaces.CategoriesUseCaseInterfaces;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly IViewCategoriesUseCase _viewCategoriesUseCase;
        private readonly IViewSelectedCategoryUseCase _viewSelectedCategoryUseCase;
        private readonly IAddCategoryUseCase _addCategoryUseCase;
        private readonly IEditCategoryUseCase _editCategoryUseCase;
        private readonly IDeleteCategoryUseCase _deleteCategoryUseCase;

        public CategoriesController(IViewCategoriesUseCase viewCategoriesUseCase,
                                    IViewSelectedCategoryUseCase viewSelectedCategoryUseCase,
                                    IAddCategoryUseCase addCategoryUseCase,
                                    IEditCategoryUseCase editCategoryUseCase,
                                    IDeleteCategoryUseCase deleteCategoryUseCase)
        {
            this._viewCategoriesUseCase = viewCategoriesUseCase;
            this._viewSelectedCategoryUseCase = viewSelectedCategoryUseCase;
            this._addCategoryUseCase = addCategoryUseCase;
            this._editCategoryUseCase = editCategoryUseCase;
            this._deleteCategoryUseCase = deleteCategoryUseCase;
        }
        public IActionResult Index()
        {
            var categories = _viewCategoriesUseCase.Execute(); //load the categories
            return View(categories); //bind the model to the view
        }

        /*Create an Action method to handle the request made when a user clicks on any item that has edit in the href attribute of an anchor tag*/
        public IActionResult Edit(int? id) //pass the id of the clicked item over to the edit method
        {
            ViewBag.Action = "edit";
            var category = _viewSelectedCategoryUseCase.Execute(id.HasValue?id.Value:0); //grab the category from the in memory repository. If that Id is valid, use zero instead.

            return View(category); //bind the view with the model
        }

        //Create an HTTPPost action method to receive the changes. By default action methods would be HTTPGet
        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if(ModelState.IsValid) //if the model is not valid based on the validation that we implemented, dont run the code inside the backets. If it is, run it.
            {
                _editCategoryUseCase.Execute(category.CategoryId, category);
            return RedirectToAction(nameof(Index));
            }
            return View(category); //take the user back to the same page with the invalid model, but displaying a validatin error message
        }

        public IActionResult Add()
        {
            ViewBag.Action = "add"; //use this to help render partial views
            return View();
        }

        [HttpPost]
        public IActionResult Add(Category category)
        {
            if (ModelState.IsValid)
            {
                _addCategoryUseCase.Execute(category);
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }
        public IActionResult Delete(int id)
        {
            _deleteCategoryUseCase.Execute(id);
            return RedirectToAction(nameof(Index));
        }


    }
}
