using System.Collections.Generic;
using System.Web.Http;
using K_Systems.Data.Persistance;
using K_Systems.Data.Core;


namespace K_Systems.APIService.Controllers
{
    [RoutePrefix("api/employees")]
    public class EmployeesController : ApiController
    {
        //private readonly IUnitOfWork _uow;

        //public EmployeesController()
        //{
        //    _uow = new UnitOfWork(new ERPModel());
        //}

        //public EmployeesController(IUnitOfWork uow)
        //{
        //    _uow = uow;
        //}

        //// GET: api/Employees
        //[HttpGet, Route("")]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { new Test("search", "employees").Route };
        //}

        //// GET: api/Employees/5
        //[HttpGet, Route("{id:int}")]
        //public string Get(int id)
        //{
        //    // Employee emp =  _uow.Employees.GetById(id);
        //    return "hiiiiiiiiii" + id;
        //}

        //[HttpGet, Route("search/{term}")]
        //public IEnumerable<string> Search(string term)
        //{
        //    return new string[] { "dfgdf" };
        //}


        //// POST: api/Employees
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT: api/Employees/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/Employees/5
        //public void Delete(int id)
        //{
        //}


    }
}
