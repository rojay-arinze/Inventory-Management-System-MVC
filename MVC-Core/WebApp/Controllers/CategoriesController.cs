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
            var category = new Category { CategoryId = id.HasValue ? id.Value : 0 }; //Create an instance of category, if the id is not null, the category id is the id else its 0

            return View(category); //bind the view with the model
        }
    }
}
