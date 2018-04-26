using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Fishare.Cookies;
using Fishare.Logic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Fishare.Controllers
{
    public class TimelineController : Controller
    {
        private int _userId;

        private PostLogic _postLogic;

        public TimelineController(IConfiguration config)
        {
            //Cookies
//            CookieClaims cookieClaims = new CookieClaims();

            //Get the current claims principal
//            var identity = (ClaimsPrincipal)Thread.CurrentPrincipal;
//
//            if (identity != null)
//            {
//                // Get the claims values
//                _userId = Convert.ToInt16(cookieClaims.GetClaim(identity, "Id"));
//            }
            //

//            _postLogic = new PostLogic(config);

        }

//        [Authorize(AuthenticationSchemes = "FishCookies")]
        public IActionResult TimeLine()
        {
            

            return View();
        }
    }
}