using STAR_WARS_LIBRARY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace STAR_WARS.Controllers
{
    public class TypeController : Controller
    {
        private TypeDataLayer _dataLayer = new TypeDataLayer();
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
        public ActionResult Create(STAR_WARS_LIBRARY.Type type)
        {
            _dataLayer.add(type);
            return this.View();
        }

        public ActionResult Edit(int id)
        {
            STAR_WARS_LIBRARY.Type unType = _dataLayer.getById(id);
            return this.View();
        }
        [HttpPost]
        public ActionResult Edit(STAR_WARS_LIBRARY.Type type)
        {
            _dataLayer.update(type);
            return this.View();
        }
    }
}