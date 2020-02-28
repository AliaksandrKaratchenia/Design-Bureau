using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Design_Bureau.Api.Models;
using Design_Bureau.BLL.Authentication__Authorization.Models;
using Microsoft.AspNetCore.Authorization;
using Design_Bureau.Entities;

namespace Design_Bureau.Api.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = Role.Admin)]
        public IActionResult Setting()
        {
            return View();
        }

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            //new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier }
            return View();
        }
    }
}
