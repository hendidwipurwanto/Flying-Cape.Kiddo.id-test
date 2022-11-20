using Microsoft.AspNetCore.Mvc;

namespace Capaci.Web.Controllers
{
    public class AdminProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
