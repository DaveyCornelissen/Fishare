using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Fishare.Cookies;
using Fishare.Logic;
using Fishare.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Fishare.Controllers
{
    public class TimelineController : Controller
    {
        private int _userId;

        private string mapRootPostImages = "images/Uploads/PostImages/";

        private PostLogic _postLogic;

        private FriendLogic _friendLogic;

        public TimelineController(IConfiguration config)
        {
            _postLogic = new PostLogic(config);

            _friendLogic = new FriendLogic(config);
        }

        [Authorize(AuthenticationSchemes = "FishCookies")]
        public IActionResult TimeLine()
        {
            TimeLineViewModel timeLineView = new TimeLineViewModel();
            timeLineView.Posts = _postLogic.GetPosts(_friendLogic.GetFriendIds(Convert.ToInt16(CookieClaims.GetCookieID(User))));
            return View(timeLineView);
        }
    }
}