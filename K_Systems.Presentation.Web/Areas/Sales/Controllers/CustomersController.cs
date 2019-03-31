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
    public class CustomersController : Controller
    {
        IUnitOfWork _Uow;

        public CustomersController()
        {
            _Uow = new UnitOfWork(new ERPModel());
        }

        // GET: Sales/Customers
        public ActionResult Index()
        {
            return View(_Uow.Customers.GetAll());
        }

        // GET: Sales/Customers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = _Uow.Customers.GetById(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // GET: Sales/Customers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sales/Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,name,phone,address")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                _Uow.Customers.Add(customer);
                _Uow.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customer);
        }

        // GET: Sales/Customers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = _Uow.Customers.GetById(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Sales/Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,name,phone,address")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                _Uow.Customers.Update(customer);
                _Uow.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        // GET: Sales/Customers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = _Uow.Customers.GetById(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Sales/Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer customer = _Uow.Customers.GetById(id);
            _Uow.Customers.Delete(id);
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
