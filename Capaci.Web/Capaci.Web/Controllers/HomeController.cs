using Capaci.BLL;
using Capaci.BLL.interfaces;

using Microsoft.AspNetCore.Mvc;

namespace Capaci.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITestService _testService;
        public HomeController(ITestService testService)
        {
            _testService = testService;
        }
        public IActionResult Index()
        {
            var result = _testService.GetTest();
            return View();
        }
    }
}
