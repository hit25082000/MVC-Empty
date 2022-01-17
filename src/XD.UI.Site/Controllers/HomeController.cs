using Microsoft.AspNetCore.Mvc;

namespace XD.UI.Site.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
