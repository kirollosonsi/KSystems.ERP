using System.Web.Mvc;

namespace K_Systems.Presentation.Web.Areas.Sales
{
    public class SalesAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Sales";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
               name: "Sales_default",
                url: "Sales/{controller}/{action}/{id}",
                defaults: new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}