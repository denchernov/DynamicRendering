using System.Web.Mvc;
using HelixHub.Feature.DynamicComponents.Models;
using Sitecore;
using Sitecore.Mvc.Controllers;
using Sitecore.Mvc.Presentation;
using Convert = System.Convert;

namespace HelixHub.Feature.DynamicComponents.Controllers
{
    public class LayoutController : SitecoreController
    {
        public ActionResult Column()
        {
            var renderingParameters = RenderingContext.Current.Rendering.Parameters;
            var colNumberString = renderingParameters["Col Number"];
            var size = renderingParameters["size"];
            var model = new ColumnModel
            {
                ColumnNumber = Convert.ToInt32(colNumberString),
                Size = size
            };


            return View("~/Views/DynamicComponents/Layout/Column.cshtml", model);
        }

        public ActionResult Row()
        {
            return View("~/Views/DynamicComponents/Layout/Row.cshtml");
        }

        public ActionResult Content()
        {
            return View("~/Views/DynamicComponents/Layout/Content.cshtml");
        }
    }
}