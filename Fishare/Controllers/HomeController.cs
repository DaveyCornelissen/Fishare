using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Fishare.ViewModels;
using Fishare.Model;
using Fishare.Logic;

namespace Fishare.Controllers
{
    using Microsoft.ApplicationInsights.Extensibility.Implementation;

    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(User model)
        {
            var AccountLogic = new Logic.AccountLogic();
            User CurrentUser = AccountLogic.checkLogin(model);
            if (CurrentUser != null)
            {
                //UserTest viewModel = new UserTest(CurrentUser);
//                CurrentUser = Se

                return RedirectToAction("TimeLine", "Timeline");
            }
            else
            {
                return View();
            }
        }
    }
}
