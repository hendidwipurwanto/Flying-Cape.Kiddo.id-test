using Capaci.BLL.interfaces;
using Capaci.DTO.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Capaci.Web.Controllers
{
    public class AdminProductController : Controller
    {
        private readonly IAdminProductService _adminProductService;
        private readonly IUploadImageService _uploadImageService;
        public AdminProductController(IAdminProductService adminProductService, IUploadImageService uploadImageService)
        {
            _adminProductService = adminProductService;
            _uploadImageService = uploadImageService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Save(ProductViewModel viewModel)
        {
           viewModel.ImagePath=_uploadImageService.Upload((viewModel.ImageFile));
           await _adminProductService.Create(viewModel);
            // return View();
            return RedirectToAction("Index", "AdminDashboard");
        }
    }
}
