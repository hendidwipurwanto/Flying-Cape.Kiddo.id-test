using Capaci.BLL.interfaces;
using Capaci.DTO.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Capaci.Web.Controllers
{
    public class SubscriptionController : Controller
    {
        private readonly ISubscriptionService _subscriptionService;
        private readonly IAdminProductService _adminProductService;
        public SubscriptionController(ISubscriptionService subscriptionService, IAdminProductService adminProductService)
        {
            _subscriptionService = subscriptionService;
            _adminProductService = adminProductService;
        }

        public async Task<IActionResult> Index(string id)
        {
            var viewmodel = new SubscriptionViewModel();
            var productviewmodel = await _adminProductService.GetById(id);
            viewmodel.Price = productviewmodel.Price;
            viewmodel.ProductId = productviewmodel.Id;
            viewmodel.ProductName = productviewmodel.Name;
            viewmodel.UserId =  System.Guid.Parse(User.Claims.FirstOrDefault().Value);


            return View(viewmodel);
        }

        public async Task<IActionResult> Save(SubscriptionViewModel viewModel)
        {
            var result = await _subscriptionService.Create(viewModel);

            return RedirectToAction("Index", "MyVideo");
        }
    }
}
