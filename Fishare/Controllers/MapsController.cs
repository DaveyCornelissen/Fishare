using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Fishare.Controllers
{
    public class MapsController : Controller
    {
        [Authorize(AuthenticationSchemes = "FishCookies")]
        public IActionResult FishMap()
        {
            return View();
        }
    }
}