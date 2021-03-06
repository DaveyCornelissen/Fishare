﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Fishare.Cookies;
using Microsoft.AspNetCore.Mvc;
using Fishare.Model;
using Fishare.Logic;
using Fishare.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;


namespace Fishare.Controllers
{
    public class AccountController : Controller
    {
        private int userId;

        private string mapRootProfileImages = "images/Uploads/ProfileImages/";

        private string mapRootPostImages = "images/Uploads/PostImages/";

        private AccountLogic _accountLogic;

        private FriendLogic _friendLogic;

        private IHostingEnvironment _hostingEnvironment;

        public AccountController(IConfiguration config, IHostingEnvironment environment)
        {
            _accountLogic = new AccountLogic(config);

            _friendLogic = new FriendLogic(config);

            _hostingEnvironment = environment;
        }

        /// <summary>
        /// Login Get action
        /// </summary>
        /// <returns></returns>
        public IActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// Logout the user and delete the cookies
        /// </summary>
        /// <returns></returns>
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
                cookieCreate.addClaims("Id", cookieInfo.UserId.ToString());
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
        public async Task<IActionResult> Create(CreateAccountViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            try
            {

                var profileImagePaCombine = Path.Combine(_hostingEnvironment.WebRootPath, mapRootProfileImages);

                string _NewFile = await AddFileToDirectory(model.PPath, profileImagePaCombine);
                string image = _NewFile ?? "";


                User _newUser = new User
                {
                    UserEmail = model.UserEmail,
                    Password = model.Password,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    BirthDay = model.Birthday,
                    PhoneNumber = model.PhoneNumber,
                    PpPath = image
                };

                _accountLogic.CreateUser(_newUser);

                return RedirectToAction("Login", "Account");
            }
            catch (ExceptionHandler exception)
            {
                ViewData[exception.Index] = exception.Message;
                return View(model);
            }
        }

        [Authorize(AuthenticationSchemes = "FishCookies")]
        public IActionResult Profile(int Id)
        {
            userId = (Id != 0)? Id : Convert.ToInt16(CookieClaims.GetCookieID(User));

            return View(GetProfileModel());
        }

        [HttpPost]
        public async Task<IActionResult> Profile(string SearchValue, string buttonType, int friendID,
            ProfileSettingsViewModel profileSettingsModel, string settingsCall, string friendCall)
        {
            userId = Convert.ToInt16(CookieClaims.GetCookieID(User));
            List<User> _searchResult = null;

            try
            {
                //for add a friend on there profile page
                if (friendID != 0 && String.IsNullOrEmpty(buttonType))
                {
                    //third parameter is the actionId default it is 0
                   _friendLogic.SendFriendRequest(userId, friendID);
                    userId = friendID;
                }

                //update Profile/Account settings
                if (settingsCall == "True")
                {
                    if (!ModelState.IsValid)
                        return PartialView(GetProfileModel());

                    //Update User Account settings
                    await ProfileSettings(profileSettingsModel);
                }

                if (friendCall == "True" || !string.IsNullOrEmpty(SearchValue))
                    _searchResult = ProfileFriends(buttonType, friendID, SearchValue);
                
                //update the cookies

                return PartialView(GetProfileModel(_searchResult));
            }
            catch (ExceptionHandler exception)
            {
                ViewData[exception.Index] = exception.Message;
                return PartialView(GetProfileModel());
            }
        }

        /// <summary>
        /// Handels everything for the friends page
        /// </summary>
        /// <param name="ButtonType"></param>
        /// <param name="friendID"></param>
        /// <param name="SearchValue"></param>
        /// <returns></returns>
        public List<User> ProfileFriends(string ButtonType = null, int friendID = 0, string SearchValue = null)
        {
            if (!String.IsNullOrEmpty(ButtonType) && friendID != 0)
            {
                switch (ButtonType)
                {
                    case "Accept":
                        _friendLogic.AcceptFriendRequest(userId, friendID);
                        break;
                    case "Decline":
                        _friendLogic.DeclineFriendRequest(userId, friendID);
                        break;
                    case "Block":
                        _friendLogic.BlockFriend(userId, friendID);
                        break;
                    case "Unblock":
                        _friendLogic.UnblockFriend(userId, friendID);
                        break;
                    case "Cancel":
                        _friendLogic.DeclineFriendRequest(userId, friendID);
                        break;
                    case "Remove":
                        _friendLogic.RemoveFriend(userId, friendID);
                        break;
                    case "Send":
                        _friendLogic.SendFriendRequest(userId, friendID);
                        break;
                    case "RemoveOwn":
                        _friendLogic.RemoveFriend(userId, friendID);
                        //To change the friends view for the guestviewer
                        userId = friendID;
                        break;
                    default:
                        ViewData["ErrorFriends"] = "Oops something when wrong with getting the friends information!";
                        break;
                }
            }

            //Checks if there is a search request
            if (!String.IsNullOrEmpty(SearchValue))
                return _friendLogic.GetSearchResult(userId, SearchValue);
            
            //Return Default
            return null;
        }

        /// <summary>
        /// Combine all the diffrent Profile ViewModels into One!
        /// </summary>
        /// <param name="_pSModel"></param>
        /// <param name="cookieUserId"></param>
        /// <returns></returns>
        private ProfileViewModel GetProfileModel(List<User> searchResult = null)
        {
            //return the new ProfileModel
            return new ProfileViewModel
            {
                ProfileInfoViewModel = ProfileInfo(),
                ProfileSettingsViewModel = ProfileSettings(),
                ProfileFriendsViewModal = ProfileFriend(searchResult)
            };
        }

        /// <summary>
        /// Get the New User Info Values from the Logic and create an ViewModel of it.
        /// </summary>
        /// <param name="cookieUserId"></param>
        /// <returns></returns>
        private ProfileInfoViewModel ProfileInfo()
        {
            //get the current user profile
            User _user = _accountLogic.GetUserProfile(userId);

             return new ProfileInfoViewModel
            {
                UserId = _user.UserId,
                FirstName = _user.FirstName,
                LastName = _user.LastName,
                PhoneNumber = _user.PhoneNumber,
                Birthday = _user.BirthDay,
                Bio = _user.Bio,
                PPath = _user.PpPath,
                Posts = _user.Posts,
                Friends = _user.Friends
            };
        }

        /// <summary>
        /// Get the New User Settings Values from the Logic and create an ViewModel of it.
        /// </summary>
        /// <param name="cookieUserId"></param>
        /// <returns></returns>
        private ProfileSettingsViewModel ProfileSettings()
        {
            //get the current user profile
            User _user = _accountLogic.GetUserProfile(userId);

            return new ProfileSettingsViewModel
            {
                UserEmail = _user.UserEmail,
                FirstName = _user.FirstName,
                LastName = _user.LastName,
                Birthday = _user.BirthDay,
                PPathView = _user.PpPath,
                PhoneNumber = _user.PhoneNumber,
                Bio = _user.Bio,
            };
        }

        /// <summary>
        /// Get the 3 Kind to friends into the friendsViewModal.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        private ProfileFriendsViewModal ProfileFriend(List<User> SearchResult = null)
        {
            List<Friend> _Acceptedfriends = _friendLogic.GetAcceptedFriends(userId);

            List<Friend> _Pendingfriends = _friendLogic.GetRequestingFriends(userId);

            List<Friend> _Blockedfriends = _friendLogic.GetBlockedFriends(userId);

            return new ProfileFriendsViewModal
            {
                UserId = userId,
                AcceptedFriends = _Acceptedfriends,
                RequestingFriends = _Pendingfriends,
                BlockedFriends = _Blockedfriends,
                SearchedFriends = SearchResult
            };
        }

        /// <summary>
        /// Update the New User to the Logic Layer
        /// </summary>
        /// <param name="profileSettingsModel"></param>
        /// <param name="cookieUserId"></param>
        private async Task ProfileSettings(ProfileSettingsViewModel profileSettingsModel)
        {
            var profileImagePaCombine = Path.Combine(_hostingEnvironment.WebRootPath, mapRootProfileImages);

            string _NewFile = await AddFileToDirectory(profileSettingsModel.PPathUpload, profileImagePaCombine);
            string image = _NewFile ?? profileSettingsModel.PPathView;

            User _newUser = new User
            {
                UserId = userId,
                UserEmail = profileSettingsModel.UserEmail,
                Password = profileSettingsModel.Password,
                FirstName = profileSettingsModel.FirstName,
                LastName = profileSettingsModel.LastName,
                BirthDay = profileSettingsModel.Birthday,
                PhoneNumber = profileSettingsModel.PhoneNumber,
                PpPath = image,
                Bio = profileSettingsModel.Bio
            };

            //update users account
            _accountLogic.UpdateUser(_newUser);
        }

       /// <summary>
        /// Adds the file to the right directory and also random creates a new name.
        /// </summary>
        /// <param name="file"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public async Task<string> AddFileToDirectory(IFormFile file, string path)
        {
            if (file != null)
            {
                try
                {
                    //Rename the filename to a new and unique filename
                    string fileName = Path.GetRandomFileName();

                    string[] uniquefileName = fileName.Split('.');

                    string extension = Path.GetExtension(file.FileName);

                    string _newFileName = file.FileName.Replace(file.FileName, uniquefileName[0]+ extension);

                    var newfilePath = Path.Combine(path, _newFileName);

                    using (var fileStream = new FileStream(newfilePath, FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);

                    }

                    //new filename
                    return _newFileName;
                }
                catch (DirectoryNotFoundException)
                {
                    Directory.CreateDirectory(path);

                   return await AddFileToDirectory(file, path);
                }
            }
            else
            {
                return null;
            }
        }
    }
}
