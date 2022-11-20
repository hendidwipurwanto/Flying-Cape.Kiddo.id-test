using Microsoft.AspNetCore.Mvc;

namespace Capaci.Web.Controllers
{
    public class GetStartedController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
