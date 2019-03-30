using K_Systems.Data.Core;
using K_Systems.Data.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace K_Systems.Presentation.Web.Areas.HR.Controllers
{
    public class DashBoardsController : Controller
    {
        private readonly IUnitOfWork _uow;

        public DashBoardsController()
        {
            _uow = new UnitOfWork(new ERPModel());
        }
        // GET: DashBoards
        public ActionResult Index()
        {
            ViewBag.employeesCount =  _uow.Employees.Count();
            ViewBag.employeesSalaries = _uow.Employees.Salaries();
            return View();
        }
    }
}