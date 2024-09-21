using WebApp.Models;

namespace WebApp.ViewModels
{
    public class SalesViewModel
    {
        public int SelectedCategoryId { get; set; }

        public List<Category> Categories { get; set; } = new List<Category>();
    }
}
