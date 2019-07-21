using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using Upload.App.Models;

namespace Upload.App.Controllers
{
    [AllowAnonymous]
    public class AuthController : Controller
    {
        [HttpGet]
        public ActionResult Login(string returnUrl)
        {
            var model = new LoginModel
            {
                ReturnUrl = returnUrl
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (model.Email == "sommer")
            {
                var identify = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, "Sommer"),
                    new Claim(ClaimTypes.Sid, "123")
                },
                "ApplicationCookie");
                var ctx = Request.GetOwinContext();
                var authManager = ctx.Authentication;
                authManager.SignIn(identify);
                return Redirect(GetRedirectUrl(model.ReturnUrl));
            }

            ModelState.AddModelError("", "Usuário ou senha inválidos");
            return View(model);
        }

        [HttpGet]
        public ActionResult LogOut()
        {
            var ctx = Request.GetOwinContext();
            var authManager = ctx.Authentication;
            authManager.SignOut("ApplicationCookie");
            return RedirectToAction("index", "upload");
        }

        public ActionResult Create()
        {
            return View(new UserModel());
        }
        [HttpPost]
        public ActionResult Create(UserModel user)
        {
            if (!ModelState.IsValid)
            {
                return View("Create");
            }
            var request = new Domain.Arguments.User.InsertUserRequest()
            {
                Email = user.Email,
                Password = user.Password
            };
            //var response = _serviceUser.InsertUser(request);
            //ViewBag.MessageUserCreate = response.Message;
            return RedirectToAction("Login");
        }

        private string GetRedirectUrl(string returnUrl)
        {
            if (string.IsNullOrEmpty(returnUrl) || !Url.IsLocalUrl(returnUrl))
            {
                return Url.Action("index", "upload");
            }

            return returnUrl;
        }
    }
}