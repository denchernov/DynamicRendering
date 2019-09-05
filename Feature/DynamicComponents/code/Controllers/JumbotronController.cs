using System.Web.Mvc;
using Sitecore.Mvc.Controllers;
using Sitecore.Mvc.Presentation;

namespace HelixHub.Feature.DynamicComponents.Controllers
{
    public class JumbotronController : SitecoreController
    {
        // GET
        public ActionResult Jumbotron()
        {
            // var contextItem = RenderingContext.Current.Rendering.Item;

            return View("~/Views/DynamicComponents/Jumbotron/JumbotronView.cshtml");
        }
    }
}