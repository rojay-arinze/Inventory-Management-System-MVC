using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class CategoriesController : Controller
    {
        public IActionResult Index()
        {
            var categories = CategoriesRepository.GetCategories(); //load the categories
            return View(categories); //bind the model to the view
        }

        /*Create an Action method to handle the request made when a user clicks on any item that has edit in the href attribute of an anchor tag*/
        public IActionResult Edit(int? id) //pass the id of the clicked item over to the edit method
        {
            var category = CategoriesRepository.GetCategoryById(id.HasValue?id.Value:0); //grab the category from the in memory repository. If that Id is valid, use zero instead.

            return View(category); //bind the view with the model
        }

        //Create an HTTPPost action method to receive the changes. By default action methods would be HTTPGet
        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if(ModelState.IsValid) //if the model is not valid based on the validation that we implemented, dont run the code inside the backets. If it is, run it.
            {

            CategoriesRepository.UpdateCategory(category.CategoryId, category);
            return RedirectToAction(nameof(Index));
            }
            return View(category); //take the user back to the same page with the invalid model, but displaying a validatin error message
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Category category)
        {
            if (ModelState.IsValid)
            {
                CategoriesRepository.AddCategory(category);
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }
        public IActionResult Delete(int id)
        {
            CategoriesRepository.DeleteCategory(id);
            return RedirectToAction(nameof(Index));
        }


    }
}
