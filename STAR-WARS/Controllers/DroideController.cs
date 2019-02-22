using STAR_WARS_LIBRARY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace STAR_WARS.Controllers
{
    public class DroideController : Controller
    {
        private DroideDataLayer _dataLayer = new DroideDataLayer();
        private TypeDataLayer _dataLayerType = new TypeDataLayer();
        // GET: Droide
        public ActionResult Index()
        {
            return View(_dataLayer.getAll());
        }
        public ActionResult Create()
        {
            this.ViewBag.ListType = _dataLayerType.getAll();
            return this.View();
        }
        // POST : Droide
        [HttpPost]
        public ActionResult Create(Droide droide)
        {
            _dataLayer.add(droide);
            this.ViewBag.ListType = _dataLayerType.getAll();
            return this.View();
        }

        public ActionResult Edit(int id)
        {
            Droide unDroide = _dataLayer.getById(id);
            this.ViewBag.ListType = _dataLayerType.getAll();
            return this.View();
        }
        [HttpPost]
        public ActionResult Edit(Droide droide)
        {
            _dataLayer.update(droide);
            this.ViewBag.ListType = _dataLayerType.getAll();
            return this.View();
        }
    }
}