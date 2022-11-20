using Microsoft.AspNetCore.Mvc;

namespace Capaci.Web.Controllers
{
    public class AdminDashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
