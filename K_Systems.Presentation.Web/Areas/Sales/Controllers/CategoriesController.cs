using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using K_Systems.Data.Core;
using K_Systems.Data.Core.Domain;
using K_Systems.Data.Persistance;

namespace K_Systems.Presentation.Web.Areas.Sales.Controllers
{
    public class CategoriesController : Controller
    {
        IUnitOfWork _Uow;

        public CategoriesController()
        {
            _Uow = new UnitOfWork(new ERPModel());
        }

        // GET: Sales/Categories
        public ActionResult Index()
        {
            return View(_Uow.Categories.GetAll());
        }

        // GET: Sales/Categories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = _Uow.Categories.GetById(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // GET: Sales/Categories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sales/Categories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,name,description")] Category category)
        {
            if (ModelState.IsValid)
            {
                _Uow.Categories.Add(category);
                _Uow.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(category);
        }

        // GET: Sales/Categories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = _Uow.Categories.GetById(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Sales/Categories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,name,description")] Category category)
        {
            if (ModelState.IsValid)
            {
                _Uow.Categories.Update(category);
                _Uow.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);
        }

        // GET: Sales/Categories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = _Uow.Categories.GetById(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Sales/Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _Uow.Categories.Delete(id);
            _Uow.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
            }
            base.Dispose(disposing);
        }
    }
}
