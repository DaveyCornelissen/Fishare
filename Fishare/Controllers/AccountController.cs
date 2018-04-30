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
using Fishare.Cookies;


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
                    CookieCreate cookieCreate = new CookieCreate();
                    cookieCreate.addClaims("Id", cookieInfo.UserID.ToString());
                    cookieCreate.addClaims("UserName", cookieInfo.UserName);
                    cookieCreate.addClaims("UserPicture", cookieInfo.PpPath);
                    var claimsPrincipal = cookieCreate.CreateCookieAuth("FishCookies");

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
        public IActionResult Create(CreateAccountViewModel model)
        {
            try
            {
                User _newUser = new User
                {
                    UserName = model.UserName,
                    UserEmail = model.UserEmail,
                    Password = model.Password,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    BirthDay = model.Birthday,
                    PhoneNumber = model.PhoneNumber,
                    PpPath = model.PPath
                };

                bool UserCreated = _accountLogic.CreateUser(_newUser);

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
            _userId = Convert.ToInt16(CookieClaims.GetCookieID(User));

            User _user = _accountLogic.GetUserProfile(_userId);

            ProfileViewModel profileView = new ProfileViewModel();
            profileView.User = _user;

            return View(profileView);
        }
    }
}
