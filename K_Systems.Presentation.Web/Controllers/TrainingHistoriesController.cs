using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using K_Systems.Data.Core.Domain;
using K_Systems.Data.Core;
using K_Systems.Data.Persistance;
using K_Systems.Presentation.Web.Models.ViewModel;

namespace K_Systems.Presentation.Web.Controllers
{
    public class TrainingHistoriesController : Controller
    {
        IUnitOfWork _uow;

        public TrainingHistoriesController()
        {
            _uow = new UnitOfWork(new ERPModel());
        }

        // GET: TrainingHistories
        public ActionResult Index(string search, int? items, int? page, string sortBy, string order)
        {
            page = page ?? 1;
            search = search ?? "";
            search = search.Trim();
            items = items ?? 10;

            TrainingHistory[] trainingHistories = _uow.TrainingHistories.GetByName(search, (int)items, sortBy, order, (int)page, out int totalPages).ToArray();

            return View(new TrainingHistoryHomeViewModel(sortBy, order)
            {
                trainingHistories = trainingHistories.ToArray(),
                search = search,
                items = (int)items,
                page = (int)page,
                totalPages = totalPages
            });
        }

        public PartialViewResult Search(string search, int? items, int? page, string sortBy, string order)
        {
            page = page ?? 1;
            search = search ?? "";
            search = search.Trim();
            items = items ?? 10;
            sortBy = string.IsNullOrEmpty(sortBy) ? "ID" : sortBy;
            order = string.IsNullOrEmpty(sortBy) ? "asc" : order;

            IEnumerable<TrainingHistory> trainingHistories = _uow.TrainingHistories.GetByName(search, (int)items, sortBy, order, (int)page, out int totalPages);

            return PartialView("_TrainingHistoryTable", new TrainingHistoryHomeViewModel(sortBy, order)
            {
                trainingHistories = trainingHistories.ToArray(),
                search = search,
                items = (int)items,
                page = (int)page,
                totalPages = totalPages
            });
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(TrainingHistory trainingHistory)
        {
            if (!ModelState.IsValid)
                return View(trainingHistory);

            _uow.TrainingHistories.Add(trainingHistory);
            _uow.SaveChanges();
            return RedirectToAction("Index");
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ContentResult AddAjax(TrainingHistory trainingHistory)
        {
            string f1 = Request.Form["empName"];
            string f2 = Request.Form["courseName"];

            if (!ModelState.IsValid)
                return Content($"<p>Failed to add course: {f2} to employee {f1}</p>");

            if(_uow.TrainingHistories.GetById(trainingHistory.employeeID,trainingHistory.courseID) != null)
                return Content($"<p>Employee {f1} already have course {f2}</p>");

            _uow.TrainingHistories.Add(trainingHistory);
            _uow.SaveChanges();
            return Content($"<p>Course {f2} have been added successfully to employee {f1}</p>");
        }

        public JsonResult EmployeeAuto(string term)
        {
            if (string.IsNullOrEmpty(term))
                return Json("", JsonRequestBehavior.AllowGet);
            object res = _uow.Employees.GetNames(term);
            return Json(res, JsonRequestBehavior.AllowGet);
        }

        public JsonResult CourseAuto(string term)
        {
            if (string.IsNullOrEmpty(term))
                return Json("", JsonRequestBehavior.AllowGet);
            object res = _uow.Courses.GetNames(term);
            return Json(res, JsonRequestBehavior.AllowGet);
        }

    }
}