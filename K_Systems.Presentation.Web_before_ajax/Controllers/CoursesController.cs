using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using K_Systems.Data.Core.Domain;
using K_Systems.Data.Core;
using K_Systems.Data.Persistance;
using K_Systems.Presentation.Web.Models.ViewModel;
using System.Net;

namespace K_Systems.Presentation.Web.Controllers
{
    public class CoursesController : Controller
    {
        IUnitOfWork _uow;

        public CoursesController()
        {
            _uow = new UnitOfWork(new ERPModel());
        }

        public CoursesController(IUnitOfWork unitOfWork = null)
        {
            _uow = unitOfWork ?? new UnitOfWork(new ERPModel());
        }

        // GET: Courses
        public ActionResult Index()
        {
            IEnumerable<Course> courses = _uow.Courses.GetByName("", 10, "ID", "asc", 1, out int totalPages);

            return View(new CourseHomeViewModel("ID", "asc")
            {
                courses = courses.ToArray(),
                search = "",
                items = 10,
                page = 1,
                totalPages = totalPages
            });
        }

        public PartialViewResult Search(string search, int? items, int? page, string sortBy, string order)
        {
            page = page ?? 1;
            search = search ?? "";
            search = search.Trim();
            items = items ?? 10;

            IEnumerable<Course> courses = _uow.Courses.GetByName(search, (int)items, sortBy, order, (int)page, out int totalPages);

            return PartialView("_CoursesTable", new CourseHomeViewModel(sortBy, order)
            {
                courses = courses.ToArray(),
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
        public ActionResult Add(Course course)
        {
            if (!ModelState.IsValid)
                return View(course);

            _uow.Courses.Add(course);
            _uow.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");

            Course course = _uow.Courses.GetById(id.Value);

            if (course == null)
                return RedirectToAction("Index");

            return View(course);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Course course)
        {
            if (!ModelState.IsValid)
                return View(course);

            _uow.Courses.Update(course);
            _uow.SaveChanges();

            return RedirectToAction("Index");
        }


        public ActionResult Detail(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");

            Course course = _uow.Courses.GetById(id.Value);
            return View(course);
        }

        public PartialViewResult CourseDetail(int? id)
        {
            if (!id.HasValue)
                return null;

            Course course = _uow.Courses.GetById(id.Value);
            if (course == null)
                return null;

            return PartialView("_CourseDetail", course);
        }

        public ActionResult Delete(int? id)
        {
            if (!id.HasValue)
                return RedirectToAction("Index");

            bool result = _uow.Courses.Delete(id.Value);
            int res = _uow.SaveChanges();

            if (result && res > 0)
                return new HttpStatusCodeResult(HttpStatusCode.OK, "Deleted");
            else
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden, "Error While Delete");
        }


    }
}