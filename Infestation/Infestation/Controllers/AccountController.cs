using Infestation.Models;
using Infestation.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Infestation.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        //private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(UserManager<ApplicationUser> userManager)
            //SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            //_signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(AccountRegisterViewModel registerViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser 
                { 
                    FirstName = registerViewModel.FirstName,
                    LastName = registerViewModel.LastName,
                    UserName = registerViewModel.UserName,
                    Email = registerViewModel.Email };
                var createTask = _userManager.CreateAsync(user, registerViewModel.Password);

                if (createTask.Result.Succeeded)
                {
                    return RedirectToAction("Index");
                }

                foreach (var error in createTask.Result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View();
        }
    }
}