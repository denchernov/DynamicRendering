namespace HelixHub.Feature.Navigation.Controllers
{
    using System.Web.Mvc;
    using System.Web.UI.WebControls;

    using Sitecore.Mvc.Controllers;

    public class NavigationController : SitecoreController
    {
        public ActionResult Header()
        {
            return View("~/Views/Navigation/Header.cshtml");
        }
    }
}