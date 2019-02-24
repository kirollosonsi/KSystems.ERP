using K_Systems.Data.Core;
using K_Systems.Data.Core.Domain;
using K_Systems.Data.Persistance;
using K_Systems.Presentation.Web.Models.ViewModel;
using K_Systems.Presentation.Web.Helper;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace K_Systems.Presentation.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUnitOfWork _uow;

        public AccountController() : this(new UnitOfWork(new ERPModel()))
        {

        }

        public AccountController(IUnitOfWork uow)
        {
            _uow = uow;
        }
        // GET: Account
        public ActionResult Login(string ReturnUrl)
        {
            return View(new LoginViewModel { ReturnUrl=ReturnUrl});
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel login)
        {
            if (!ModelState.IsValid)
                return View(login);

            UserERP loggedUser = _uow.UserManager.FindByEmailAndPassword(login.Email, login.Password);
            if (loggedUser == null)
            {
                ModelState.AddModelError("Error", "Username or password are incorrect");
                ViewBag.message = "Username or password are incorrect";
                return View(login);
            }

            ClaimsIdentity identity = _uow.UserManager.CreateIdentity(loggedUser, "ApplicationCookie");
            Request.GetOwinContext().Authentication.SignIn(identity);

            return Redirect(GetRedirectUrl(login.ReturnUrl));
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel login)
        {
            if (!ModelState.IsValid)
                return View(login);

            if (IsUserExist(login))
            {
                ViewBag.message = "Already Existing User ...";
                ModelState.AddModelError("Error", "Already Existing User ...");
                return View(login);
            }

            UserERP newUser = new UserERP
            {
                Email = login.Email,
                UserName = login.UserName,
                EmployeeId = 1
            };

            IdentityResult createResult = _uow.UserManager.Create(newUser, login.Password);

            if (!createResult.Succeeded)
            {
                ViewBag.message = "Error in Creating User, \n Please try Aagin later ...";
                ModelState.AddModelError("Error", "Already Existing User ...");
                return View(login);
            }
            ClaimsIdentity identity = _uow.UserManager.CreateIdentity(newUser, "ApplicationCookie");

            Request.GetOwinContext().Authentication.SignIn(identity);

            return Redirect(GetRedirectUrl(login.retunURL));
        }


        [HttpGet]
        public ActionResult Logout()
        {
            Request.GetOwinContext().Authentication.SignOut("ApplicationCookie");
            return RedirectToAction("Index", "Home");
        }
        [Authorize]
        public ActionResult Manage()
        {
            ClaimsIdentity claimsIdentity = User.Identity as ClaimsIdentity;

            string userId = claimsIdentity.GetUserId();
            UserERP user = _uow.UserManager.FindById(userId);
            return View(new RegisterViewModel
            {
                UserName = user.UserName,
                Email = user.Email
            });
        }

        private UserERP GetUserERP(RegisterViewModel login)
        {
            return new UserERP
            {
                Email = login.Email,
                UserName = login.UserName,
                EmployeeId = 1
            };
        }

        //private IdentityResult CreateUser(LoginViewModel login)
        //{

        //}

        private ClaimsIdentity GetUserIdentity(RegisterViewModel login)
        {
            UserERP user = GetUserERP(login);
            return _uow.UserManager.CreateIdentity(user, "ApplicationCookie");
        }

        private bool IsUserExist(RegisterViewModel login)
        {
            if (login == null)
                return false;
            return _uow.UserManager.FindByEmail(login.Email) == null ? false : true;
        }

        private string GetRedirectUrl(string returnUrl)
        {
            if (string.IsNullOrEmpty(returnUrl) || !Url.IsLocalUrl(returnUrl))
            {
                return Url.Action("index", "home");
            }
            return returnUrl;
        }
    }
}