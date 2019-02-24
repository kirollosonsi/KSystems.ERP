using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Reflection;
using System.Web.Http;
using System.Web.Http.Routing;

namespace K_Systems.APIService.Helpers
{
    public static class HelperMethods
    {

        //public static string GetRouteURL(string actionName, string controllerName)
        //{
        //    return GetRouteURL(actionName, controllerName);
        //}
        ////public static string GetRouteURL(string actionName, string controllerName)
        //{
        //    string urlPrefix;
        //    string urlSegments;

        //    Type controllerType = Assembly.GetCallingAssembly()
        //        .GetTypes()
        //        .SingleOrDefault(t =>
        //        t.BaseType == typeof(ApiController) && t.Name.ToLower() == controllerName.ToLower());

        //    if (controllerType == null)
        //        return "";

        //    CustomAttributeData urlPrefixAttr = controllerType
        //        .CustomAttributes
        //        .SingleOrDefault(a => a.AttributeType == typeof(RoutePrefixAttribute));

        //    urlPrefix = urlPrefixAttr == null ? "" : urlPrefixAttr.ConstructorArguments[0].Value.ToString();

        //    MethodInfo mInfo = controllerType.GetMethods().SingleOrDefault(m => m.Name.ToLower() == actionName.ToLower());

        //    CustomAttributeData urlSegmentAttr = mInfo
        //        .CustomAttributes
        //        .SingleOrDefault(a => a.AttributeType == typeof(RouteAttribute));

        //    if (urlSegmentAttr == null)
        //        urlSegments = actionName;
        //    else
        //    {
        //        urlSegments = urlSegmentAttr.ConstructorArguments[0].Value.ToString();
        //        int index = urlSegments.IndexOf('/');
        //        //urlSegments = urlSegments.
        //    }


        //    return string.Format(@"{0}/{1}", urlPrefix, actionName);
        //}
    }
}