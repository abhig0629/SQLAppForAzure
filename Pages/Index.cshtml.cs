using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SQLAppForAzure.Models;
using SQLAppForAzure.Services;

namespace SQLAppForAzure.Pages
{
    public class IndexModel : PageModel
    {

        public List<Product> products = new List<Product>();
        
        public void OnGet()
        {
            ProductService productService = new ProductService();
            products = productService.GetProducts();
        }
    }
}