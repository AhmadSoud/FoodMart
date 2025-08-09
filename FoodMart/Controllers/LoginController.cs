using Microsoft.AspNetCore.Mvc;

namespace FoodMart.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Login()
        {
            return View(); // يبحث عن Views/Login/Login.cshtml تلقائيًا
        }

    }
}
