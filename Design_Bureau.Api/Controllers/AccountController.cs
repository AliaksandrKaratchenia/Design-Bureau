using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Design_Bureau.Api.Models;
using Design_Bureau.BLL.Authentication__authorization;
using Design_Bureau.BLL.Authentication__Authorization.Models;
using Design_Bureau.DAL.Repositories;
using Design_Bureau.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Design_Bureau.Api.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _service;
        private readonly IRepository<ChiefDesigner> _chiefRepository;
        private readonly IRepository<Customer> _customerRepository;

        public AccountController(IUserService service, IRepository<ChiefDesigner> chiefRepository, IRepository<Customer> customerRepository)
        {
            _service = service;
            _chiefRepository = chiefRepository;
            _customerRepository = customerRepository;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new User { Username = model.UserName, Password = model.Password };
                user.Role = user.Username.Contains("@admin") ? Role.Admin : Role.User;
                var identity = await _service.RegisterAsync(user);
                if (identity == null)
                {
                    ModelState.AddModelError("", "Can not register, try again");
                    return View(model);
                }

                if (user.Role == Role.Admin)
                {
                    await _chiefRepository.Insert(new ChiefDesigner { Name = model.UserName });
                }
                else
                {
                    await _customerRepository.Insert(new Customer { Name = model.UserName });
                }
                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new User { Username = model.UserName, Password = model.Password };
                var identity = _service.Authenticate(user);
                if (identity == null)
                {
                    ModelState.AddModelError("", "Can not login, try again");
                    return View(model);
                }
                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }
    }
}