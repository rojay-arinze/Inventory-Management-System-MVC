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
    }
}
