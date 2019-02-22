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
        private HistoriqueDataLayer historiqueLayer = new HistoriqueDataLayer();
        private DroideDataLayer droideLayer = new DroideDataLayer();
        private WookieDataLayer wookieLayer = new WookieDataLayer();

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

        [HttpPost]
        public ActionResult End(int nbWookie, int nbDroide, string planete, string nomBataille)
        {
            ActionResult result = this.RedirectToAction("Index", "Login");
            if (this.Session["USER_LOGIN"] != null && !string.IsNullOrEmpty(this.Session["USER_LOGIN"].ToString()))
            {
                

                ViewBag.bataille = nomBataille;
                ViewBag.nbWookie = nbWookie;
                ViewBag.nbDroide = nbDroide;
                ViewBag.planete = planete;

                List<Droide> droides = new List<Droide>();
                List<Wookie> wookies = new List<Wookie>();

                for (int i = 0; i < nbDroide; i++)
                {
                    Droide droide = new Droide { Matricule =Guid.NewGuid().ToString(), DateDeF = DateTime.Now, TypeID=1 };
                    droideLayer.add(droide);

                    droide.ID = droideLayer.getAll().Last().ID;

                    droides.Add(droide);

                    Historique historique = new Historique { DroideID = droideLayer.getAll().Last().ID, pointsDeVie = 100, DateDeH = DateTime.Now };
                    historiqueLayer.add(historique);
                }

                for (int i = 0; i < nbWookie; i++)
                {
                    Wookie wookie = new Wookie { Nom= Guid.NewGuid().ToString(), DateDeN=DateTime.Now, PlaneteID=1};
                    
                    wookieLayer.add(wookie);
                    wookies.Add(wookie);

                    wookie.ID = wookieLayer.getAll().Last().ID;

                    Historique historique = new Historique { WookieID = wookieLayer.getAll().Last().ID, pointsDeVie = 100, DateDeH = DateTime.Now };
                    historiqueLayer.add(historique);
                }

                Random random = new Random();
                Random attaque = new Random();

                string vainqueur = "DROIDES";

                while(droides.Count()> 0 && wookies.Count() > 0)
                {

                    Wookie wookiePourCombat = wookies[random.Next(0, wookies.Count()-1)];
                    Droide droidePourCombat = droides[random.Next(0, droides.Count()-1)];

                    if (random.Next(0, 100)<80)
                    {
                        Historique historiqueWookie = new Historique { WookieID = wookiePourCombat.ID, pointsDeVie = 100, DateDeH = DateTime.Now };
                        historiqueLayer.add(historiqueWookie);

                        Historique historiqueDroide = new Historique { DroideID = droidePourCombat.ID, pointsDeVie = 0, DateDeH = DateTime.Now };
                        historiqueLayer.add(historiqueDroide);

                        droides.Remove(droidePourCombat);
                    }
                    else
                    {
                        Historique historiqueWookie = new Historique { WookieID = wookiePourCombat.ID, pointsDeVie = 0, DateDeH = DateTime.Now };
                        historiqueLayer.add(historiqueWookie);

                        Historique historiqueDroide = new Historique { DroideID = droidePourCombat.ID, pointsDeVie = 100, DateDeH = DateTime.Now };
                        historiqueLayer.add(historiqueDroide);

                        wookies.Remove(wookiePourCombat);
                    }

                }

                if(droides.Count() == 0)
                {
                    vainqueur = "WOOKIES";
                }

                ViewBag.vainqueur = vainqueur;
                ViewBag.nbDroideFinal = droides.Count();
                ViewBag.nbWookieFinal = wookies.Count();

                result = this.View();
            }
            return result;

        }
    }
}