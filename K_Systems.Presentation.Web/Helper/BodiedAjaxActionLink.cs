using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using K_Systems.Data.Core.Domain;

namespace K_Systems.Presentation.Web.Helper
{
    public static class HelperExtensions
    {
        public static MvcHtmlString BodiedActionLink(this AjaxHelper ajaxHelper, string linkText, string actionName, string controllerName, TablePageInfo routeValues, AjaxOptions ajaxOptions, object htmlAttributes)
        {
            var repID = "_";
            var lnk = ajaxHelper.ActionLink(repID, actionName, controllerName, routeValues, ajaxOptions, htmlAttributes);
            return MvcHtmlString.Create(lnk.ToString().Replace(repID,linkText));
        }
    }
}

