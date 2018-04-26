using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using Fishare.Cookies;
using Microsoft.AspNetCore.Mvc;
using Fishare.Model;
using Fishare.Logic;
using Fishare.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;


namespace Fishare.Controllers
{
    public class AccountController : Controller
    {
        private int _userId;

        private AccountLogic _accountLogic;

        public AccountController(IConfiguration config)
        {


            _accountLogic = new AccountLogic(config);

        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            bool userExist = _accountLogic.CheckLogin(model.Email, model.Password);

            if (userExist)
            {
                User cookieInfo = _accountLogic.GetCookieInfo(model.Email);

                if (cookieInfo != null)
                {
                    CookieClaims cookieClaims = new CookieClaims();
                    cookieClaims.addClaims("Id", cookieInfo.UserID.ToString());
                    var claimsPrincipal = cookieClaims.CreateCookieAuth("FishCookies");

                    Response.Cookies.Append("UserID", cookieInfo.UserID.ToString());

                    //to login the user
                    await HttpContext.SignInAsync(
                        "FishCookies", claimsPrincipal,
                        new AuthenticationProperties
                        {
                            IsPersistent = model.Remember
                        });

                    return RedirectToAction("TimeLine", "Timeline");
                }
                else
                {
                    ViewData["ErrorGetUser"] = "Oops something went wrong!";
                    return View();
                }
            }
            else
            {
                ViewData["ErrorNoUser"] = "Email or password does not exist! Please try again";
                return View();
            }
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(User model)
        {
            try
            {
                bool UserCreated = _accountLogic.CreateUser(model);

                if (UserCreated)
                {
                    ViewData["UserCreateSucces"] = "Your account is successfull created! You can now login.";
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    ViewData["UserCreateFailed"] = "Oops something went wrong! your account has failed to create!";
                    return View();
                }
            }
            catch (ExceptionHandler exception)
            {
                ViewData[exception.Index] = exception.Message;
                return View();
            }
        }

        public IActionResult Profile()
        {
            _userId = Convert.ToInt16(Request.Cookies["UserID"]);

            User User = _accountLogic.GetUserProfile(_userId);

            ProfileViewModel profileView = new ProfileViewModel();
            profileView.User = User;

            return View(profileView);
        }
    }
}
