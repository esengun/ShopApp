using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ShopApp.WebUI.Identity;
using ShopApp.WebUI.Models;

namespace ShopApp.WebUI.Controllers
{
	public class AccountController: Controller
	{
		private UserManager<User> _userManager;

		private SignInManager<User> _signInManager; // manages cookie operations

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
			_signInManager = signInManager;
        }
        public IActionResult Login()
		{
			return View();
		}

		public IActionResult Register()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Register(RegisterModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			var user = new User()
			{
				FirstName = model.FirstName, 
				LastName = model.LastName,
				UserName = model.UserName,
				Email = model.Email				
			};

			var result = await _userManager.CreateAsync(user, model.Password);
			if(result.Succeeded)
			{
				// generate token
				// send confirmation email
				return RedirectToAction("Login", "Account");
			}

			ModelState.AddModelError("Password", "InvalidPassword"); // add error messages in case of an error on identity response
			ModelState.AddModelError("", "Error occured try again!");

			return View(model);
		}
	}
}
