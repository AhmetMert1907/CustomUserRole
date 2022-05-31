using AutoMapper;
using CustomUserRole.Insfrastructure.Context;
using CustomUserRole.Models.Entities;
using CustomUserRole.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CustomUserRole.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        MyDbContext db = new MyDbContext();
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel model)
        {
            var user = Mapper.Map<User>(model);
            var existUser = db.Users.FirstOrDefault(x => x.UserName == user.UserName);
            if (existUser == null)
            {
                Role role = db.Roles.FirstOrDefault(x => x.RoleName.Contains(model.Role));
                user.Roles.Add(role);
                db.Entry<User>(user).State = EntityState.Added;
                db.SaveChanges();
            }
            return RedirectToAction("Login");
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model, string ReturnUrl = "")
        {
            var user = db.Users.FirstOrDefault(x => x.Email == model.Email && x.Password == model.Password);
            if (user == null)
            {
                return View(model);
            }
            var roles = "Admin"; // returns a string e.g. "admin,user"
            var authTicket = new FormsAuthenticationTicket(
                              1,
                              user.UserName,
                              DateTime.Now,
                              DateTime.Now.AddMinutes(20), // expiry
                              false,
                              roles,
                              "/");
            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName,
              FormsAuthentication.Encrypt(authTicket));
            Response.Cookies.Add(cookie);
            //FormsAuthentication.SetAuthCookie(user.UserName, false);
            if (ReturnUrl != "")
            {
                return Redirect(ReturnUrl);
            }
            return RedirectToAction("Index", "Home");
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}