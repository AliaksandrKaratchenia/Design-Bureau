﻿using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Design_Bureau.Api.Models;
using Microsoft.AspNetCore.Authorization;
using Design_Bureau.Entities;

namespace Design_Bureau.Api.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        [Authorize(Roles ="Admin, User")]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles ="Admin")]
        public IActionResult Setting()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            var designers = new List<Designer>
            {
                new Designer
                {
                    Name = "Adam"
                },
                new Designer
                {
                    Name = "Jon"
                }};
            var multiStoreyHouseProject = new MultiStoreyHouseProject
            {
                Designers = designers
            };
            return View(multiStoreyHouseProject);
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
