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
        private BatailleDataLayer batailleLayer = new BatailleDataLayer();

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
        public ActionResult Fight(int nbWookie, int nbDroide, int planete, string nomBataille)
        {
            ActionResult result = this.RedirectToAction("Index", "Login");
            if (this.Session["USER_LOGIN"] != null && !string.IsNullOrEmpty(this.Session["USER_LOGIN"].ToString()))
            {

                Bataille bataille = new Bataille { Nom = nomBataille, PlaneteID = _dataLayer.getById(planete).ID };

                batailleLayer.add(bataille);

                ViewBag.bataille = bataille.Nom;
                ViewBag.nbWookie = nbWookie;
                ViewBag.nbDroide = nbDroide;
                ViewBag.planete = _dataLayer.getById(planete);
                result = this.View();
            }
            return result;

        }
    }
}