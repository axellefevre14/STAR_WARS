using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace STAR_WARS.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Index(string email, string password)
        {

            this.Session["USER_LOGIN"] = email;
            this.Session["USER_PASSWORD"] = password;


            return RedirectToAction("Fight", "Game", new { nbWookies = 50, nbDroides = 1000, nomPlanete = "Dagoba" });
        }

    }
}