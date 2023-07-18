using Microsoft.AspNetCore.Mvc;

namespace ShopManagementSystem.Controllers
{
    public class ItemsController : Controller
    {
        public IActionResult Item()
        {
            return View();
        }
    }
}
