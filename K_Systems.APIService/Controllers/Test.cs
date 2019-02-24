using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace K_Systems.APIService.Controllers
{
    public class Test:ApiController
    {
        public string Route;
        public Test(string actionName, string controllerName)
        {
            var route = Configuration
                .Routes
                .SingleOrDefault(r => (r.RouteTemplate.ToUpper().Contains(actionName.ToUpper()) && r.RouteTemplate.ToUpper().Contains(controllerName.ToUpper())));
            Route =  route == null ? "" : route.RouteTemplate;
        }
        //public string getget(string actionName, string controllerName)
        //{

        //}
    }
}