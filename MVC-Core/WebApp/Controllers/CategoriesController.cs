using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class CategoriesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        /*Create an Action method to handle the request made when a user clicks on any item that has edit in the href attribute of an anchor tag*/
        public IActionResult Edit(int? id) //pass the id of the clicked item over to the edit method
        {
            if(id.HasValue)
            {
                return new ContentResult { Content = id.ToString() };  //Populate the web page with the id of the clicked item.

            }
            else
            {
                return new ContentResult { Content = "null content" };
            }
        }
    }
}
