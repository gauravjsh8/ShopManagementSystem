using Microsoft.AspNetCore.Mvc;

namespace ShopManagementSystem.Controllers
{
    public class ItemsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
