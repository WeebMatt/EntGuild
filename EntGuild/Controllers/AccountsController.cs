using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EntGuild.Data;
using EntGuild.Models;

// Being worked on by Myles Hobson - c3379678
// CODE NOT COMPLETED/FULLY FUNCITONING!!

namespace EntGuild.Controllers
{
    public class AccountsController : Controller
    {
        private UserManager<User> userManager;
        private LoginManager<User> loginManager;
        
        public AccountsController(UserManager<User> userMngr, LoginManager<User> loginMngr)
        {
            userManager = userMngr;
            loginManager = loginMngr;
        }

        [HttpPost]
        public async Task<IActionResult> LoginAcc(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await loginManager.PasswordSignInAsync(model.Username, model.Password, isPersistent: model.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                    {
                        return Redirect(model.ReturnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            ModelState.AddModelError("", "Invalid username/password combination!");
            return View(model);
        }

        [HttpGet]
        public IActionResult RegisterAcc()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterAcc(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new User { UserName = model.Username };
                var result = await userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await LoginManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> LogOut()
        {
            await LoginManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult LogIn(string returnURL = "")
        {
            var model = new LoginModel { ReturnUrl = returnURL };
            return View(model);
        }

    }
}