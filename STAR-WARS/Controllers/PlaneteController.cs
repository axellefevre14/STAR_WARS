using STAR_WARS_LIBRARY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace STAR_WARS.Controllers
{
    public class PlaneteController : Controller
    {
        private PlaneteDataLayer _dataLayer = new PlaneteDataLayer();
        // GET: Type
        public ActionResult Index()
        {
            return View(_dataLayer.getAll());
        }
        public ActionResult Create()
        {
            return this.View();
        }
        // POST : Type
        [HttpPost]
        public ActionResult Create(Planete planete)
        {
            _dataLayer.add(planete);
            return this.View();
        }

        public ActionResult Edit(int id)
        {
            Planete unePlanete = _dataLayer.getById(id);
            return this.View();
        }
        [HttpPost]
        public ActionResult Edit(Planete planete)
        {
            _dataLayer.update(planete);
            return this.View();
        }
    }
}