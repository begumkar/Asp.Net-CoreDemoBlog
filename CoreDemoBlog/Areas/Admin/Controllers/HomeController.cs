using Microsoft.AspNetCore.Mvc;

namespace CoreDemoBlog.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
