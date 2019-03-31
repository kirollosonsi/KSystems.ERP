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
    public class ProductsController : Controller
    {
        IUnitOfWork _Uow;

        public ProductsController()
        {
            _Uow = new UnitOfWork(new ERPModel());
        }

        // GET: Sales/Products
        public ActionResult Index()
        {
            return View(_Uow.Products.GetAllWithCatSup());
        }

        // GET: Sales/Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = _Uow.Products.GetById(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Sales/Products/Create
        public ActionResult Create()
        {
            ViewBag.categoryID = new SelectList(_Uow.Categories.GetAll(), "ID", "name");
            ViewBag.supplierID = new SelectList(_Uow.Suppliers.GetAll(), "ID", "companyName");
            return View();
        }

        // POST: Sales/Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,name,price,categoryID,supplierID,quantity")] Product product)
        {
            if (ModelState.IsValid)
            {
                _Uow.Products.Add(product);
                _Uow.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.categoryID = new SelectList(_Uow.Categories.GetAll(), "ID", "name", product.categoryID);
            ViewBag.supplierID = new SelectList(_Uow.Suppliers.GetAll(), "ID", "companyName", product.supplierID);
            return View(product);
        }

        // GET: Sales/Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = _Uow.Products.GetById(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.categoryID = new SelectList(_Uow.Categories.GetAll(), "ID", "name", product.categoryID);
            ViewBag.supplierID = new SelectList(_Uow.Suppliers.GetAll(), "ID", "companyName", product.supplierID);
            return View(product);
        }

        // POST: Sales/Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,name,price,categoryID,supplierID,quantity")] Product product)
        {
            if (ModelState.IsValid)
            {
                _Uow.Products.Update(product);
                _Uow.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.categoryID = new SelectList(_Uow.Categories.GetAll(), "ID", "name", product.categoryID);
            ViewBag.supplierID = new SelectList(_Uow.Suppliers.GetAll(), "ID", "companyName", product.supplierID);
            return View(product);
        }

        // GET: Sales/Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = _Uow.Products.GetById(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Sales/Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _Uow.Products.Delete(id);
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
