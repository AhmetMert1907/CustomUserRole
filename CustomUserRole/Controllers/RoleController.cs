using CustomUserRole.Insfrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CustomUserRole.Controllers
{
    public class RoleController : Controller
    {
        MyDbContext db = new MyDbContext();
        // GET: Role
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetRoles()
        {
            TempData["roles"] = db.Roles.ToList();
            return PartialView(db.Roles.ToList());
        }
    }
}