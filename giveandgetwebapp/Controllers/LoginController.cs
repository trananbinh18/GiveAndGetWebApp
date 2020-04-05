using giveandgetwebapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace giveandgetwebapp.Controllers
{
    public class LoginController : Controller
    {
        private cap22t6Entities db = new cap22t6Entities();

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(LoginModel user) {
            AdminWeb admin = db.AdminWebs.Where(x => x.Email == user.Email && x.Password == user.Password).FirstOrDefault();
            if (admin != null) {
                Session.Add("Id", admin.Id);
                Session.Timeout = 720;
            }
            
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Logout() {
            Session.Clear();

            return RedirectToAction("Index", "Home");
        }
    }
}