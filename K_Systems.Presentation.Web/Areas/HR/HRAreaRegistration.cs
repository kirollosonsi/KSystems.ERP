using System.Web.Mvc;

namespace K_Systems.Presentation.Web.Areas.HR
{
    public class HRAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "HR";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
               name: "HR_default",
                url: "HR/{controller}/{action}/{id}",
                defaults: new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}