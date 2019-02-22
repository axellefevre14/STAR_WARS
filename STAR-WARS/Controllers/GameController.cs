using STAR_WARS_LIBRARY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace STAR_WARS.Controllers
{
    public class GameController : Controller
    {
        private PlaneteDataLayer _dataLayer = new PlaneteDataLayer();

        public ActionResult Index()
        {
            ActionResult result = this.RedirectToAction("Index", "Login");
            if (this.Session["USER_LOGIN"] != null && !string.IsNullOrEmpty(this.Session["USER_LOGIN"].ToString()))
            {
                result = this.View(_dataLayer.getAll());
            }
            return result;

        }

        // GET: Game
        public ActionResult Fight(int nombreWookie, int nombreDroide, string planete)
        {
            ActionResult result = this.RedirectToAction("Index", "Login");
            if (this.Session["USER_LOGIN"] != null && !string.IsNullOrEmpty(this.Session["USER_LOGIN"].ToString()))
            {
                result = this.View();
            }
            return result;

        }
    }
}