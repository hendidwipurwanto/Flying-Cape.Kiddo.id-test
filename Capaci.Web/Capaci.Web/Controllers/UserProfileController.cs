using AutoMapper;
using Capaci.BLL.interfaces;
using Capaci.DTO.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Capaci.Web.Controllers
{
    public class UserProfileController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IUserDetailService _userDetailService;
        private readonly IMapper _mapper; 


        public UserProfileController(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager,
                                 SignInManager<IdentityUser> signInManager, IUserDetailService userDetailService, IMapper mapper)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            _roleManager = roleManager;
            _userDetailService = userDetailService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index(string email)
        {
            //string email = email;
            var user = await userManager.FindByEmailAsync(email);
           string guId = user.Id.ToString();


            var result = await _userDetailService.GetById(guId);
            
            var viewModel = new UserDetailViewModel(); //{ Email = email, FullAddress= result.FullAddress, PhoneNumber=result.PhoneNumber, FullName=result.FullName};
            _mapper.Map(result, viewModel);
            viewModel.Id = guId;
            return View(viewModel);
        }

        public async Task<IActionResult> Save(UserDetailViewModel viewModel)
        {
            var result = await _userDetailService.Update(viewModel);

            return View();
        }
    }
}
