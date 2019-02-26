using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using K_Systems.Data.Persistance;
using K_Systems.Data.Core.Domain;
using K_Systems.Data.Core.Repositories;
using K_Systems.Data.Core;
using K_Systems.Presentation.Web.Models.ViewModel;

namespace K_Systems.Presentation.Web.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IUnitOfWork _uow;

        public OrdersController()
        {
            _uow = new UnitOfWork(new ERPModel());
        }

        // GET: Employees
        public ActionResult Index(TablePageInfo pageInfo)
        {
            IEnumerable<Order> orders = _uow.Orders.FullSearch(pageInfo, out int totalPages);
            return View(new OrderHomeViewModel()
            {
                orders = orders,
                pageInfo = pageInfo,
                totalPages = totalPages
            });
        }

        public PartialViewResult Search(TablePageInfo pageInfo)
        {
            IEnumerable<Order> orders = _uow.Orders.FullSearch(pageInfo, out int totalPages);

            return PartialView("_OrderTable", new OrderHomeViewModel()
            {
                orders = orders,
                pageInfo = pageInfo,
                totalPages = totalPages
            });
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(OrderDetailViewModel orderModel)
        {
            orderModel.order.orderDate = DateTime.Now;
            _uow.Orders.Add(orderModel.order);
            _uow.SaveChanges();
            foreach (OrderDetail item in orderModel.OrderDetails)
            {
                item.orderID = orderModel.order.ID;
                _uow.OrderDetails.Add(item);
            }
            _uow.SaveChanges();
            return View();
        }

        public JsonResult EmployeesAuto(string term)
        {
            if (string.IsNullOrEmpty(term))
                return Json("", JsonRequestBehavior.AllowGet);
            object res = _uow.Employees.GetNames(term);
            return Json(res, JsonRequestBehavior.AllowGet);
        }

        public JsonResult CustomersAuto(string term)
        {
            if (string.IsNullOrEmpty(term))
                return Json("", JsonRequestBehavior.AllowGet);
            object res = _uow.Customers.GetNames(term);
            return Json(res, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ProductsAuto(string term)
        {
            if (string.IsNullOrEmpty(term))
                return Json("", JsonRequestBehavior.AllowGet);
            object res = _uow.Products.GetNames(term);
            return Json(res, JsonRequestBehavior.AllowGet);
        }
    }
}