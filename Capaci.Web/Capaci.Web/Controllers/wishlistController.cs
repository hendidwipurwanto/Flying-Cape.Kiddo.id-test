using Microsoft.AspNetCore.Mvc;

namespace Capaci.Web.Controllers
{
    public class wishlistController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
