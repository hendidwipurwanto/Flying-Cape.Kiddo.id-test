using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Capaci.Web.Controllers
{

    [Authorize]
    public class wishlistController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
