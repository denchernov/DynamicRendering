using System.Web.Mvc;
using Sitecore.Mvc.Controllers;

namespace HelixHub.Feature.DynamicComponents.Controllers
{
    public class ListController : SitecoreController
    {
        // GET
        public ActionResult Index()
        {
            return View("~/Views/DynamicComponents/List/ListView.cshtml", new object());
        }
    }
}