using Capaci.BLL.interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Capaci.Web.Controllers
{
    [Authorize]
    public class MyVideoController : Controller
    {
        private readonly IAdminProductService _adminProductService;
        private readonly ISubscriptionService _subscriptionService;
        public MyVideoController(IAdminProductService adminProductService, ISubscriptionService subscriptionService)
        {
            _adminProductService = adminProductService;
            _subscriptionService = subscriptionService;
        }

        public async Task<IActionResult> Index()
        {
            var uid = User.Claims.FirstOrDefault().Value;





            var list = await _subscriptionService.GetByUserId(Guid.Parse(uid));

            return View(list);
        }
    }
}
