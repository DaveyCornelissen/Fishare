﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Fishare.Controllers
{
    public class TimelineController : Controller
    {
        [Authorize(AuthenticationSchemes = "FishCookies")]
        public IActionResult TimeLine()
        {
            

            return View();
        }
    }
}