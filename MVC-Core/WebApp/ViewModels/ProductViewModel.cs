using WebApp.Models;
/*This ViewModel is used to pass multiple pieces of data to the view. We needed to pass a product along with a list of categories.*/
namespace WebApp.ViewModels
{
    public class ProductViewModel
    {
        public IEnumerable<Category> Categories { get; set; } = new List<Category>();

        public Product Product { get; set; } = new Product();
    }
}
