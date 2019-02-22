using STAR_WARS_LIBRARY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace STAR_WARS.Controllers
{
    public class WookieController : Controller
    {
        private WookieDataLayer _dataLayer = new WookieDataLayer();
        private PlaneteDataLayer _dataLayerPlanete = new PlaneteDataLayer();
        // GET: Wookie
        public ActionResult Index()
        {
            return View(_dataLayer.getAll());
        }


        public ActionResult Create()
        {
            this.ViewBag.ListPlanete = _dataLayerPlanete.getAll();
            return this.View();
        }

        // POST : Wookie
        [HttpPost]
        public ActionResult Create(Wookie wookie)
        {
            _dataLayer.add(wookie);
            this.ViewBag.ListPlanete = _dataLayerPlanete.getAll();
            return this.View();
        }

        public ActionResult Edit(int id)
        {
            Wookie unWookie = _dataLayer.getById(id);
            this.ViewBag.ListPlanete = _dataLayerPlanete.getAll();
            return this.View();
        }
        [HttpPost]
        public ActionResult Edit(Wookie wookie)
        {
            _dataLayer.update(wookie);
            this.ViewBag.ListPlanete = _dataLayerPlanete.getAll();
            return this.View();
        }
    }
}