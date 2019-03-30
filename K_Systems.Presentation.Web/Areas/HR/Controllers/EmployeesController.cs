using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using K_Systems.Data.Core.Domain;
using K_Systems.Data.Core;
using K_Systems.Data.Persistance;
using K_Systems.Presentation.Web.Helper;
using K_Systems.Presentation.Web.Models.ViewModel;
using K_Systems.Presentation.Web.Models;
using System.Net;
using System.Security.Claims;
using Microsoft.AspNet.Identity;

namespace K_Systems.Presentation.Web.Areas.HR.Controllers
{
    public class EmployeesController : Controller
    {
        IUnitOfWork _uow;
        private readonly string uploadedImagesPath = "~/uploads/images/";
        private readonly string serverPath = "/uploads/images";
        private readonly string placeholderImageFileName = "placeholder.jpg";

        public EmployeesController(IUnitOfWork unitOfWork = null)
        {
            this._uow = unitOfWork ?? new UnitOfWork(new ERPModel());
        }

        public EmployeesController() : this(new UnitOfWork(new ERPModel()))
        {
        }

        // GET: Employees
        public ActionResult Index(TablePageInfo pageInfo)
        {
            IEnumerable<Employee> employees = _uow.Employees.FullSearch(pageInfo, out int totalPages);

            if (User.Identity.IsAuthenticated)
            {
                ClaimsIdentity userClaims = ((ClaimsIdentity)User.Identity);
                string userId = userClaims.GetUserId();

                Claim itemsClaim = userClaims
                    .Claims
                    .FirstOrDefault(c => c.Type == "items");

                if (itemsClaim != null)
                    pageInfo.items = Convert.ToInt32(itemsClaim.Value);
            }

            return View(new EmployeeHomeViewModel()
            {
                employees = employees,
                pageInfo = pageInfo,
                totalPages = totalPages
            });
        }

        public PartialViewResult Search(TablePageInfo pageInfo)
        {
            if (User.Identity.IsAuthenticated)
            {
                ClaimsIdentity userClaims = ((ClaimsIdentity)User.Identity);
                string userId = userClaims.GetUserId();

                Claim itemsClaim = userClaims
                    .Claims
                    .FirstOrDefault(c => c.Type == "items");

                //Claim claim = new Claim("items",items.Value.ToString());
                //_uow.UserManager.AddClaim(userId, claim);
            }

            IEnumerable<Employee> employees = _uow.Employees.FullSearch(pageInfo, out int totalPages);

            return PartialView("_EmployeesTable", new EmployeeHomeViewModel()
            {
                employees = employees.ToArray(),
                pageInfo = pageInfo,
                totalPages = totalPages
            });
        }

        public ActionResult Add()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Add(HttpPostedFileBase uploadImg, Employee employee)
        {
            if (!ModelState.IsValid)
                return View(employee);

            employee.img = FileManipulation.SavePhoto(uploadImg, Server.MapPath(uploadedImagesPath));

            _uow.Employees.Add(employee);
            _uow.SaveChanges();
            return RedirectToAction("Index");
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ContentResult AddAjax(HttpPostedFileBase uploadImg, Employee employee)
        {
            if (!ModelState.IsValid)
                return Content($"<p>Failed to add the following employee: {employee.fName} {employee.lName}</p>");

            employee.img = FileManipulation.SavePhoto(uploadImg, Server.MapPath(uploadedImagesPath));

            _uow.Employees.Add(employee);
            _uow.SaveChanges();
            return Content($"<p>Employee {employee.fName} {employee.lName} have been added successfully</p>");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");

            Employee employee = _uow.Employees.GetById(id.Value);
            if (string.IsNullOrEmpty(employee.img))
                employee.img = FileManipulation.GetFileFullPath(serverPath, placeholderImageFileName);
            else
                employee.img = FileManipulation.GetFileFullPath(serverPath, employee.img);

            return View(employee);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Edit(HttpPostedFileBase uploadImg, Employee updatedEmployee)
        {
            if (!ModelState.IsValid)
                return View(updatedEmployee);

            string imageName = FileManipulation.SavePhoto(uploadImg, Server.MapPath(uploadedImagesPath));
            string oldEmpImg = FileManipulation.GetFileName(updatedEmployee.img);

            if (!string.IsNullOrEmpty(imageName))
            {
                FileManipulation.DeletePhoto(Server.MapPath(uploadedImagesPath), oldEmpImg);
                updatedEmployee.img = imageName;
            }
            else
            {
                if (oldEmpImg == placeholderImageFileName)
                    updatedEmployee.img = null;
                else
                    updatedEmployee.img = oldEmpImg;
            }

            _uow.Employees.Update(updatedEmployee);
            _uow.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Detail(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");

            Employee employee = _uow.Employees.GetById(id.Value);
            if (string.IsNullOrEmpty(employee.img))
                employee.img = FileManipulation.GetFileFullPath(serverPath, placeholderImageFileName);
            else
                employee.img = FileManipulation.GetFileFullPath(serverPath, employee.img);

            return View(employee);
        }

        public ActionResult EmpDetail(int? id)
        {
            if (!id.HasValue)
                return null;

            Employee employee = _uow.Employees.GetById(id.Value);
            if (employee == null)
                return null;

            if (string.IsNullOrEmpty(employee.img))
                employee.img = FileManipulation.GetFileFullPath(serverPath, placeholderImageFileName);
            else
                employee.img = FileManipulation.GetFileFullPath(serverPath, employee.img);

            return PartialView("_EmployeeDetail", employee);
        }

        public ActionResult Delete(int? id)
        {
            if (!id.HasValue)
                return RedirectToAction("Index");

            bool result = _uow.Employees.LogicalDelete(id.Value);

            if (result)
                return new HttpStatusCodeResult(HttpStatusCode.OK, "Deleted");
            else
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden, "Error While Delete");
        }
    }
}