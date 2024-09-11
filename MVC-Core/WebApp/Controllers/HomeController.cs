using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        public string Index()
        {
            return "Hello World";
        }

        public string Error()
        {
            return "Error LOL";
        }
    }
}
