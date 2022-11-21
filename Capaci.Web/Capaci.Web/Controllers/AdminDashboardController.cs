using Capaci.BLL.interfaces;
using Capaci.DTO.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Capaci.Web.Controllers
{
    public class AdminDashboardController : Controller
    {
        private readonly IAdminProductService _adminProductService;
        public AdminDashboardController(IAdminProductService adminProductService)
        {
            _adminProductService = adminProductService;
        }

        public async Task<IActionResult> Index()
        {
            var productList = await _adminProductService.GetAll();
            
            //var list = new List<ProductViewModel>();
            //list.AddRange(productList);

            return View(productList);
        }
    }
}
