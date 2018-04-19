using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Fishare.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Fishare.Controllers
{
    public class TimelineController : Controller
    {
        [Authorize(AuthenticationSchemes = "FishCookies")]
        public IActionResult TimeLine()
        {
            CookieClaims cookieClaims = new CookieClaims();

            //Get the current claims principal
            var identity = (ClaimsPrincipal)Thread.CurrentPrincipal;

            if (identity != null)
            {
               // Get the claims values
               string userid = cookieClaims.GetClaim(identity, "Id");
            }

            return View();
        }
    }
}