using AutoMapper;
using Capaci.BLL.interfaces;
using Capaci.DTO.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Capaci.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IUserDetailService _userDetailService;
        private readonly IMapper _mapper;
        public AccountController(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager,
                                 SignInManager<IdentityUser> signInManager, IUserDetailService userDetailService, IMapper mapper)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            _roleManager = roleManager;
            _userDetailService = userDetailService;
            _mapper = mapper;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatorRegister(RegisterViewModel viewModel)

        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }
             //   var defaultRole = new IdentityRole() { Name = "Creator", };
             //   await _roleManager.CreateAsync(defaultRole);

                var user = new IdentityUser { UserName = viewModel.Email, Email = viewModel.Email, EmailConfirmed = true };
                string guId = user.Id.ToString();
                viewModel.Id = new Guid(guId);
                //var userDetailViewModel = new UserDetailViewModel() { Email = viewModel.Email, FullAddress = viewModel.FullAddress, FullName = viewModel.FullName, PhoneNumber = viewModel.PhoneNumber };
                var userDetailViewModel = new UserDetailViewModel();
                _mapper.Map(viewModel, userDetailViewModel);
                
                await _userDetailService.Create(userDetailViewModel);
                var result = await userManager.CreateAsync(user, viewModel.Password);
                var result2 = await userManager.AddToRoleAsync(user, "Creator");
                //var aktifitas = new AktifitasUserViewModel { UserName = User.Identity.Name, TanggalAktifitasStringFormat = DateTime.Now.ToString("dd/M/yyyy HH:mm:ss", CultureInfo.InvariantCulture), Aktifitas = "Menambahkan User[" + user.UserName + "]" };
                //await _listAktifitasUserService.Create(aktifitas);
               if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("index", "CreatorDashboard");
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }


            return View();
        }
        public IActionResult CreatorRegister()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel viewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }
               var user = new IdentityUser { UserName = viewModel.Email, Email = viewModel.Email, EmailConfirmed = true };
                string guId = user.Id.ToString();
                viewModel.Id = new Guid(guId);
              //  await _userDetailService.Create(viewModel);
                var result = await userManager.CreateAsync(user, viewModel.Password);
                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("index", "Home");
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(viewModel.UserName, viewModel.Password, viewModel.RememberMe, false);

                if (result.Succeeded)
                {
                    var user = await userManager.FindByEmailAsync(viewModel.UserName);
                    var roles = await userManager.GetRolesAsync(user);

                    if (roles.Count > 1)
                    {
                        return RedirectToAction("index", "Dashboard");
                    }
                    else
                    {

                        return RedirectToAction("index", "Home");
                    }
                 }
                ModelState.AddModelError(string.Empty, "Maaf!,Anda tidak bisa Login saat ini, tolong cek kembali user dan password Anda atau Kemungkinan Akun Anda belom ter-Registrasi dalam Sistem Kami,Selanjutnya Silahkan hubungi Admin Anda!");

            }

            return View(viewModel);
        }
    }
}
