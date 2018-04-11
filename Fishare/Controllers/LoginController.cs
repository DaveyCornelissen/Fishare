using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Fishare.Model;
using Fishare.Logic;
using Fishare.ViewModels;
using Fishare.Factory;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Configuration;

namespace Fishare.Controllers
{

    public class LoginController : Controller
    {
        private IConfiguration Config;
        private Factory.Factory Factory;

        public LoginController(IConfiguration Config)
        {
            this.Config = Config;
            Factory = new Factory.Factory(this.Config);

        }


        public IActionResult UserLogin()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UserLogin(LoginViewModel model)
        {
            var AccountLogic = Factory.AccountInfo();

            bool userExist = AccountLogic.UserExist(model);

            if (userExist)
            {
                User UserInfo = AccountLogic.GetInfoUser(model);

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, UserInfo.UserName),
                };

                var claimsIdentity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);

                return RedirectToAction("TimeLine", "Timeline");
            }
            else
            {
                return View();
            }
        }
    }
}
