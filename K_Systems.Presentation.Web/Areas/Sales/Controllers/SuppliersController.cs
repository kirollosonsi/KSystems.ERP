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
    public class SuppliersController : Controller
    {
        IUnitOfWork _Uow;

        public SuppliersController()
        {
            _Uow = new UnitOfWork(new ERPModel());
        }

        // GET: Sales/Suppliers
        public ActionResult Index()
        {
            return View(_Uow.Suppliers.GetAll());
        }

        // GET: Sales/Suppliers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supplier supplier = _Uow.Suppliers.GetById(id);
            if (supplier == null)
            {
                return HttpNotFound();
            }
            return View(supplier);
        }

        // GET: Sales/Suppliers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sales/Suppliers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,companyName,contactName,address,mobile,extraInfo")] Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                _Uow.Suppliers.Add(supplier);
                _Uow.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(supplier);
        }

        // GET: Sales/Suppliers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supplier supplier = _Uow.Suppliers.GetById(id);
            if (supplier == null)
            {
                return HttpNotFound();
            }
            return View(supplier);
        }

        // POST: Sales/Suppliers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,companyName,contactName,address,mobile,extraInfo")] Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                _Uow.Suppliers.Update(supplier);
                _Uow.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(supplier);
        }

        // GET: Sales/Suppliers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supplier supplier = _Uow.Suppliers.GetById(id);
            if (supplier == null)
            {
                return HttpNotFound();
            }
            return View(supplier);
        }

        // POST: Sales/Suppliers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _Uow.Suppliers.Delete(id);
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
