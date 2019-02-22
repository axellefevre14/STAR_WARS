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

        [HttpPost]
        public ActionResult Fight(int nbWookie, int nbDroide, int planete)
        {
            ActionResult result = this.RedirectToAction("Index", "Login");
            if (this.Session["USER_LOGIN"] != null && !string.IsNullOrEmpty(this.Session["USER_LOGIN"].ToString()))
            {
                ViewBag.nbWookie = nbWookie;
                ViewBag.nbDroide = nbDroide;
                ViewBag.planete = _dataLayer.getById(planete);
                result = this.View();
            }
            return result;

        }
    }
}