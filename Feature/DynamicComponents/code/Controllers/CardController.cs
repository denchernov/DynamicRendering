using System.Web.Mvc;
using Sitecore.Mvc.Controllers;

namespace HelixHub.Feature.DynamicComponents.Controllers
{
    public class CardController : SitecoreController
    {
        public ActionResult Card()
        {
            return View("~/Views/DynamicComponents/Card/Card.cshtml");
        }
    }
}