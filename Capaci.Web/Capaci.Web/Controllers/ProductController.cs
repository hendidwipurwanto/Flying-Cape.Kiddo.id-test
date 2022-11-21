using Capaci.BLL.interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Capaci.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IAdminProductService _adminProductService;
        public ProductController(IAdminProductService adminProductService)
        {
            _adminProductService = adminProductService;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _adminProductService.GetAll();

            return View(list);
        }
    }
}
