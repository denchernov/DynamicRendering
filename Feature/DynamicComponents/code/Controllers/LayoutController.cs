using System.Web.Mvc;
using Sitecore.Mvc.Controllers;

namespace HelixHub.Feature.DynamicComponents.Controllers
{
    public class LayoutController : SitecoreController
    {
        public ActionResult Container()
        {
            return View("~/Views/DynamicComponents/Layout/Container.cshtml");
        }

        public ActionResult Row()
        {
            return View("~/Views/DynamicComponents/Layout/Row.cshtml");
        }
    }
}