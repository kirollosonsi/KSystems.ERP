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

        public JsonResult EmployeeAuto(string term)
        {
            if (string.IsNullOrEmpty(term))
                return Json("", JsonRequestBehavior.AllowGet);
            object res = _uow.Employees.GetNames(term);
            return Json(res, JsonRequestBehavior.AllowGet);

        }

    }
}