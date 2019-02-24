using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;

namespace K_Systems.APIService.Helpers
{
    public class MyActivator : IHttpControllerSelector
    {
        public IDictionary<string, HttpControllerDescriptor> GetControllerMapping()
        {
            throw new NotImplementedException();
        }

        public HttpControllerDescriptor SelectController(HttpRequestMessage request)
        {
            if (request.RequestUri.Segments[0] == "employees")
            {
                return new HttpControllerDescriptor();
            }
            return new HttpControllerDescriptor();
        }
    }
}