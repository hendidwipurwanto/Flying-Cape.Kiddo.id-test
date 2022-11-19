using Microsoft.AspNetCore.Mvc;

namespace Capaci.Web.Controllers
{
    public class MyVideoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
