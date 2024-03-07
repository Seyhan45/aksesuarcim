using aksesuarcim.Dto;
using aksesuarcim.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp;

namespace aksesuarcim.Controllers
{
	public class MyAccountController : Controller
	{
		private readonly UserManager<AppUser> _userManager;

		public MyAccountController(UserManager<AppUser> userManager)
		{
			_userManager = userManager;
		}

		[HttpGet]
		public async Task<IActionResult> Index()
		{
			var values = await _userManager.FindByNameAsync(User.Identity.Name);
			AppUserEditDto appUserEditDto = new AppUserEditDto();
			appUserEditDto.FirstName = values.FirstName;
			appUserEditDto.LastName = values.LastName;
			appUserEditDto.PhoneNumber = values.PhoneNumber;
			appUserEditDto.Email = values.Email;
			appUserEditDto.City = values.City;
			return View(appUserEditDto);
		}
		[HttpPost]
		public async Task<IActionResult> Index(AppUserEditDto appUserEditDto)
		{
            if (appUserEditDto.Password == appUserEditDto.ConfirmPassword)
            {
                var user = await _userManager.FindByNameAsync(appUserEditDto.FirstName);
                user.FirstName = appUserEditDto.FirstName;
                user.LastName = appUserEditDto.LastName;
                user.City = appUserEditDto.City;
                user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, appUserEditDto.Password);
                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "MyAccount");
                }
            }

            return View();
        }
	}
}
