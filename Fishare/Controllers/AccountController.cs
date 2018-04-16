using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Fishare.Model;
using Fishare.Logic;
using Fishare.ViewModels;
using Fishare.Factory;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Configuration;

namespace Fishare.Controllers
{

    public class AccountController : Controller
    {
        private IConfiguration Config;
        private Factory.Factory Factory;

        public AccountController(IConfiguration Config)
        {
            this.Config = Config;
            Factory = new Factory.Factory(this.Config);

        }


        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var AccountLogic = Factory.AccountInfo();

            bool userExist = AccountLogic.UserExist(model);

            if (userExist)
            {
                User UserInfo = AccountLogic.GetInfoUser(model);

                var Claims = new List<Claim>
                {
                    new Claim("Id", UserInfo.UserID.ToString()),
                    new Claim("Name", UserInfo.UserName),
                };

                var claimsIdentity = new ClaimsIdentity(
                    Claims, "FishCookies");

                await HttpContext.SignInAsync(
                    "FishCookies",
                    new ClaimsPrincipal(claimsIdentity),
                    new AuthenticationProperties
                    {
                        IsPersistent = model.Remember
                    });

                return RedirectToAction("TimeLine", "Timeline");
            } 
            else
            {
                return View();
            }
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}
