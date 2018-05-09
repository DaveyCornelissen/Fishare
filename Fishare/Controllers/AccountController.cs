using System;
using System.Threading.Tasks;
using Fishare.Cookies;
using Microsoft.AspNetCore.Mvc;
using Fishare.Model;
using Fishare.Logic;
using Fishare.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Configuration;


namespace Fishare.Controllers
{
    public class AccountController : Controller
    {
        private int cookieUserID;

        private AccountLogic _accountLogic;

        public AccountController(IConfiguration config)
        {
            _accountLogic = new AccountLogic(config);
        }

        public IActionResult Login()
        {
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(
                "FishCookies");

            return RedirectToAction("Login", "Account");
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            try
            {
                //check if the user input is valid
                _accountLogic.CheckLogin(model.Email, model.Password);
                //Get the cookie info
                User cookieInfo = _accountLogic.GetCookieInfo(model.Email);

                CookieCreate cookieCreate = new CookieCreate();
                cookieCreate.addClaims("Id", cookieInfo.UserID.ToString());
                cookieCreate.addClaims("UserName", cookieInfo.FirstName);
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
            catch (ExceptionHandler exception)
            {
                ViewData[exception.Index] = exception.Message;
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
            if (!ModelState.IsValid)
                return View(model);

            try
            {
                User _newUser = new User
                {
                    UserEmail = model.UserEmail,
                    Password = model.Password,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    BirthDay = model.Birthday,
                    PhoneNumber = model.PhoneNumber,
                    PpPath = model.PPath
                };

                _accountLogic.CreateUser(_newUser);

                return RedirectToAction("Login", "Account");
            }
            catch (ExceptionHandler exception)
            {
                ViewData[exception.Index] = exception.Message;
                return View();
            }
        }

        public IActionResult Profile()
        {
            cookieUserID = Convert.ToInt16(CookieClaims.GetCookieID(User));

            return View(GetProfileModel(cookieUserID));
        }

        [HttpPost]
        public IActionResult Profile(ProfileSettingsViewModel profileSettingsModel)
        {
            if (!ModelState.IsValid)
                return PartialView();

            cookieUserID = Convert.ToInt16(CookieClaims.GetCookieID(User));

            try
            {
                //Update User Account settings
                ProfileSettings(profileSettingsModel, cookieUserID);

                return PartialView(GetProfileModel(cookieUserID));
            }
            catch (ExceptionHandler exception)
            {
                ViewData[exception.Index] = exception.Message;
                return PartialView(GetProfileModel(cookieUserID));
            }
        }

        /// <summary>
        /// Combine all the diffrent Profile ViewModels into One!
        /// </summary>
        /// <param name="_pSModel"></param>
        /// <param name="cookieUserId"></param>
        /// <returns></returns>
        private ProfileViewModel GetProfileModel(int cookieUserId)
        {
            //return the new ProfileModel
            return new ProfileViewModel
            {
                ProfileInfoViewModel = ProfileInfo(cookieUserId),
                ProfileSettingsViewModel = ProfileSettings(cookieUserId)
            };
        }

        /// <summary>
        /// Get the New User Info Values from the Logic and create an ViewModel of it.
        /// </summary>
        /// <param name="cookieUserId"></param>
        /// <returns></returns>
        private ProfileInfoViewModel ProfileInfo(int cookieUserId)
        {
            //get the current user profile
            User _user = _accountLogic.GetUserProfile(cookieUserId);

             return new ProfileInfoViewModel
            {
                FirstName = _user.FirstName,
                LastName = _user.LastName,
                PhoneNumber = _user.PhoneNumber,
                Birthday = _user.BirthDay,
                Bio = _user.Bio,
                PPath = _user.PpPath,
                TotalFriends = _user.TotalFriends,
                Friends = _user.Friends,
                Posts = _user.Posts
            };
        }

        /// <summary>
        /// Get the New User Settings Values from the Logic and create an ViewModel of it.
        /// </summary>
        /// <param name="cookieUserId"></param>
        /// <returns></returns>
        private ProfileSettingsViewModel ProfileSettings(int cookieUserId)
        {
            //get the current user profile
            User _user = _accountLogic.GetUserProfile(cookieUserId);

            return new ProfileSettingsViewModel
            {
                UserEmail = _user.UserEmail,
                FirstName = _user.FirstName,
                LastName = _user.LastName,
                Birthday = _user.BirthDay,
                PPath = _user.PpPath,
                PhoneNumber = _user.PhoneNumber,
                Bio = _user.Bio,
            };
        }

        /// <summary>
        /// Update the New User to the Logic Layer
        /// </summary>
        /// <param name="profileSettingsModel"></param>
        /// <param name="cookieUserId"></param>
        private void ProfileSettings(ProfileSettingsViewModel profileSettingsModel,
            int cookieUserId)
        {
            User _newUser = new User
            {
                UserID = cookieUserId,
                UserEmail = profileSettingsModel.UserEmail,
                Password = profileSettingsModel.Password,
                FirstName = profileSettingsModel.FirstName,
                LastName = profileSettingsModel.LastName,
                BirthDay = profileSettingsModel.Birthday,
                PhoneNumber = profileSettingsModel.PhoneNumber,
                PpPath = profileSettingsModel.PPath,
                Bio = profileSettingsModel.Bio
            };

            //update users account
            _accountLogic.UpdateUser(_newUser);
        }
    }
}
