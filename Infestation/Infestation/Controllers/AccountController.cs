using Infestation.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infestation.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
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
                var user = new IdentityUser { UserName = registerViewModel.UserName, Email = registerViewModel.Email };
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
